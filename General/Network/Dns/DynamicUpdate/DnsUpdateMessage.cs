using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using DreamRecorder.ToolBox.Network.Dns.DnsRecord;

namespace DreamRecorder.ToolBox.Network.Dns.DynamicUpdate;

/// <summary>
///     <para>Dynamic DNS update message</para>
///     <para>
///         Defined in
///         <see cref="!:http://tools.ietf.org/html/rfc2136">RFC 2136</see>
///     </para>
/// </summary>
public class DnsUpdateMessage : DnsMessageBase
{

	private List <PrerequisiteBase> _prequisites;

	private List <UpdateBase> _updates;

	internal override bool IsTcpResendingRequested => false;

	internal override bool IsTcpUsingRequested => false;

	/// <summary>
	///     Gets or sets the entries in the prerequisites section
	/// </summary>
	public List <PrerequisiteBase> Prequisites
	{
		get => _prequisites ?? ( _prequisites = new List <PrerequisiteBase> ( ) );
		set => _prequisites = value;
	}

	/// <summary>
	///     Gets or sets the entries in the update section
	/// </summary>
	public List <UpdateBase> Updates
	{
		get => _updates ?? ( _updates = new List <UpdateBase> ( ) );
		set => _updates = value;
	}

	/// <summary>
	///     Gets or sets the zone name
	/// </summary>
	public DomainName ZoneName
	{
		get => Questions.Count > 0 ? Questions [ 0 ].Name : null;
		set => Questions = new List <DnsQuestion> { new DnsQuestion ( value , RecordType.Soa , RecordClass.INet ) , };
	}

	/// <summary>
	///     Creates a new instance of the DnsUpdateMessage class
	/// </summary>
	public DnsUpdateMessage ( ) => OperationCode = OperationCode.Update;

	/// <summary>
	///     Creates a new instance of the DnsUpdateMessage as response to the current instance
	/// </summary>
	/// <returns>A new instance of the DnsUpdateMessage as response to the current instance</returns>
	public DnsUpdateMessage CreateResponseInstance ( )
	{
		DnsUpdateMessage result = new DnsUpdateMessage
								  {
									  TransactionId = TransactionId ,
									  IsEDnsEnabled = IsEDnsEnabled ,
									  IsQuery       = false ,
									  OperationCode = OperationCode ,
									  Questions     = new List <DnsQuestion> ( Questions ) ,
								  };

		if ( IsEDnsEnabled )
		{
			result.EDnsOptions.Version        = EDnsOptions.Version;
			result.EDnsOptions.UdpPayloadSize = EDnsOptions.UdpPayloadSize;
		}

		return result;
	}

	protected override void FinishParsing ( )
	{
		Prequisites = AnswerRecords.ConvertAll <PrerequisiteBase> (
																   record =>
																   {
																	   if ( ( record.RecordClass == RecordClass.Any )
																			&& ( record.RecordDataLength == 0 ) )
																	   {
																		   return new RecordExistsPrerequisite (
																			record.Name ,
																			record.RecordType );
																	   }
																	   else if ( record.RecordClass == RecordClass.Any )
																	   {
																		   return new RecordExistsPrerequisite (
																			record );
																	   }
																	   else if ( ( record.RecordClass
																								== RecordClass.None )
																					&& ( record.RecordDataLength
																								== 0 ) )
																	   {
																		   return new RecordNotExistsPrerequisite (
																			record.Name ,
																			record.RecordType );
																	   }
																	   else if ( ( record.RecordClass
																								== RecordClass.Any )
																					&& ( record.RecordType
																								== RecordType.Any ) )
																	   {
																		   return new NameIsInUsePrerequisite (
																			record.Name );
																	   }
																	   else if ( ( record.RecordClass
																								== RecordClass.None )
																					&& ( record.RecordType
																								== RecordType.Any ) )
																	   {
																		   return new NameIsNotInUsePrerequisite (
																			record.Name );
																	   }
																	   else
																	   {
																		   return null;
																	   }
																   } ).
									Where ( prequisite => ( prequisite != null ) ).
									ToList ( );

		Updates = AuthorityRecords.ConvertAll <UpdateBase> (
															record =>
															{
																if ( record.TimeToLive != 0 )
																{
																	return new AddRecordUpdate ( record );
																}
																else if ( ( record.RecordType == RecordType.Any )
																		  && ( record.RecordClass == RecordClass.Any )
																		  && ( record.RecordDataLength == 0 ) )
																{
																	return new DeleteAllRecordsUpdate ( record.Name );
																}
																else if ( ( record.RecordClass == RecordClass.Any )
																		  && ( record.RecordDataLength == 0 ) )
																{
																	return new DeleteRecordUpdate (
																	 record.Name ,
																	 record.RecordType );
																}
																else if ( record.RecordClass == RecordClass.None )
																{
																	return new DeleteRecordUpdate ( record );
																}
																else
																{
																	return null;
																}
															} ).
								   Where ( update => ( update != null ) ).
								   ToList ( );
	}

	internal override bool IsTcpNextMessageWaiting ( bool isSubsequentResponseMessage ) => false;

	/// <summary>
	///     Parses a the contents of a byte array as DnsUpdateMessage
	/// </summary>
	/// <param name="data">Buffer, that contains the message data</param>
	/// <returns>A new instance of the DnsUpdateMessage class</returns>
	public static DnsUpdateMessage Parse ( byte [ ] data ) => Parse <DnsUpdateMessage> ( data );

	protected override void PrepareEncoding ( )
	{
		AnswerRecords    = Prequisites?.Cast <DnsRecordBase> ( ).ToList ( ) ?? new List <DnsRecordBase> ( );
		AuthorityRecords = Updates?.Cast <DnsRecordBase> ( ).ToList ( )     ?? new List <DnsRecordBase> ( );
	}

}
