﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General ;

public static class PredicateExtensions
{

	public static Predicate<T> Or<T>(params Predicate<T>[] predicates) => item => predicates . Any ( predicate => predicate ( item ) ) ;


	public static Predicate<T> And<T>(params Predicate<T>[] predicates) => item => predicates . All ( predicate => predicate ( item ) ) ;

}
