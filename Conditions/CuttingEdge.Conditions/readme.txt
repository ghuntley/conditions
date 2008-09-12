This project contains the CuttingEdge.Conditions library. It enables developers to validate pre- and 
postconditions in a fluent manner. Following blogposts describe more about the library:
	Introduction to CuttingEdge.Conditions: http://www.cuttingedge.it/blogs/steven/pivot/entry.php?id=38
	Requirements and Design descisions: http://www.cuttingedge.it/blogs/steven/pivot/entry.php?id=36
	Extending CuttingEdge.Conditions: http://www.cuttingedge.it/blogs/steven/pivot/entry.php?id=39

Below are some notes on the implementation specially for developers.

Notes:
	Coding style:
		Microsoft StyleCop is used as tool to ensure a consistant coding style throughout the library.
		The project has a Settings.SourceAnalysis xml file containing the settings for StyleCop.
		
	Framework Design Guidelines:
		Microsoft FxCop is used to validate the .NET Framework Design Guidelines. The solution folder contains
		a Conditions.FxCop xml file containing the settings for FxCop.	

	Generic type constraint:
		All compare methods implement the generic type constraint 'where T : IComparable'. While the 
		constraint is not needed for those methods to work, it will prevent the methods to show up on types
		that usually can't be prepared anyway. This helps keeping the API as clean as possible.

	Comparing Nullable<T>
		Because Nullable<T> doesn't implement IComparable there are special overloads of all the compare
		methods that have a Validator<Nullable<T>> validator argument.

Optimizations:
	New in the beta 2 release are a lot of overloads for primitive types (like, int, double, etc). While
	they won't enrich the API, they will improve performance cases where those primitive types are used
	in compare validations. The primitive overloads are much faster than the generic 'where T : ICompare'
	compare methods.	
	
	The libraries code is optimized in such a way that many methods become a candidate for inlining. For a 
	method to be able to be inlined, the following conditions must hold:
	1. Methods must be really short with a maximum of 32 bytes of IL;
	2. The method must not contain exception logic or loops.
	(for more information on inlining constraints, please visit David Notario's WebLog:
	 http://blogs.msdn.com/davidnotario/archive/2004/11/01/250398.aspx)

	To achieve this, the 'throw' logic is moved out of the methods and is replaced by a call to the static 
	Throw class. All methods that never would be a candidate for inlining (because it was impossible to 
	reach the 32 bytes limit), but were interesting to optimize, were refactored in such a way that they 
	only call methods that on their turn would be inlined by the JIT compiler. Methods that can not be
	inlined are marked with an special attribute. There is a unit test that checks unmarked methods on their
	size. This way changes to method size will get noticed. Note that this unit test will only run in Release
	mode, because methods tend to be bigger in debug mode.