﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns . DynamicUpdate
{

	/// <summary>
	///     Prequisite, that a name does not exist
	/// </summary>
	public class NameIsNotInUsePrerequisite : PrerequisiteBase
	{

		protected internal override int MaximumRecordDataLength => 0 ;

		internal NameIsNotInUsePrerequisite ( ) { }

		/// <summary>
		///     Creates a new instance of the NameIsNotInUsePrerequisite class
		/// </summary>
		/// <param name="name"> Name that should be checked </param>
		public NameIsNotInUsePrerequisite ( DomainName name ) : base (
																	  name ,
																	  RecordType . Any ,
																	  RecordClass . None ,
																	  0 )
		{
		}

		protected internal override void EncodeRecordData (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical )
		{
		}

		internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length ) { }

	}

}
