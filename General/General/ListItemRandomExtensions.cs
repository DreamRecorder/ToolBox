﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	public static class ListItemRandomExtensions
	{

		/// <summary>
		///     Choose item randomly from a list, item may be chosen multiple times.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <param name="count"></param>
		/// <param name="random"></param>
		/// <returns></returns>
		public static List <T> RandomChoose <T> ( [NotNull] this IList <T> list , int count , IRandom random = null )
		{
			if ( list == null )
			{
				throw new ArgumentNullException ( nameof ( list ) ) ;
			}

			if ( count < 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof ( count ) ) ;
			}

			if ( ! list . Any ( ) )
			{
				throw new InvalidOperationException ( "Sequence contains no elements" ) ;
			}

			List <T> result = new List <T> ( count ) ;
			random ??= StaticRandom . Current ;

			for ( int i = 0 ; i < count ; i++ )
			{
				result . Add ( list . RandomItem ( random ) ) ;
			}

			return result ;
		}

		public static T RandomItem <T> ( [NotNull] this IList <T> list , IRandom random = null )
		{
			if ( list == null )
			{
				throw new ArgumentNullException ( nameof ( list ) ) ;
			}

			if ( ! list . Any ( ) )
			{
				throw new InvalidOperationException ( "Sequence contains no elements" ) ;
			}

			random ??= StaticRandom . Current ;

			return list [ random . Next ( list . Count ) ] ;
		}

		public static T RandomItem <T> ( [NotNull] this IRandom random , IList <T> list )
		{
			if ( random == null )
			{
				throw new ArgumentNullException ( nameof ( random ) ) ;
			}

			if ( list == null )
			{
				throw new ArgumentNullException ( nameof ( list ) ) ;
			}

			if ( ! list . Any ( ) )
			{
				throw new InvalidOperationException ( "Sequence contains no elements" ) ;
			}

			return list [ random . Next ( list . Count ) ] ;
		}

		/// <summary>
		///     Choose item randomly from a list, item may only be chosen one time.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <param name="count"></param>
		/// <param name="random"></param>
		/// <returns></returns>
		public static List <T> RandomUniqueChoose <T> (
			[NotNull] this IList <T> list ,
			int                      count ,
			IRandom                  random = null )
		{
			if ( list == null )
			{
				throw new ArgumentNullException ( nameof ( list ) ) ;
			}

			if ( count <= 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof ( count ) ) ;
			}

			if ( list . Count == 0 )
			{
				throw new InvalidOperationException ( "Sequence contains no elements" ) ;
			}

			if ( list . Count < count )
			{
				throw new ArgumentOutOfRangeException ( nameof ( count ) ) ;
			}

			random ??= StaticRandom . Current ;

			return random . Permutation ( list . Count - 1 , count ) . Select ( index => list [ index ] ) . ToList ( ) ;
		}

		public static IList <T> Shuffle <T> ( [NotNull] this IList <T> list , IRandom random = null )
		{
			if ( list == null )
			{
				throw new ArgumentNullException ( nameof ( list ) ) ;
			}

			random ??= StaticRandom . Current ;
			int n = list . Count ;
			while ( n > 1 )
			{
				n-- ;
				int k = random . Next ( n + 1 ) ;
				( list [ k ] , list [ n ] ) = ( list [ n ] , list [ k ] ) ;
			}

			return list ;
		}

	}

}
