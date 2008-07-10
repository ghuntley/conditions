This project contains the CuttingEdge.Conditions library. It enables developers to validate pre- and 
postconditions in a fluent manner. Other documents will explain how you can use the library. Below are some
notes on the implementation specially for developers.

Notes:
	Generic type constraint:
		All compare methods implement the generic type constraint 'where T : IComparable'. While the 
		constraint is not needed for those methods to work, it will prevent the methods to show up on types
		that usually can't be prepared anyway. This helps keeping the API as clean as possible.

	Comparing Nullable<T>
		Because Nullable<T> doesn't implement IComparable there are special overloads of all the compare
		methods that have a Validator<Nullable<T>> validator argument.

Optimizations:
	The following code is optimized in such a way that many methods become a candidate for inlining.

	For a method to be able to be inlined, the following conditions must hold:
	1. Methods must be really short with a maximum of 32 bytes of IL;
	2. The method must not contain exception logic or loops.
	3. A method must not have struct* arguments or a struct return type.
	(for more information on inlining constraints, please visit David Notario's WebLog:
	 http://blogs.msdn.com/davidnotario/archive/2004/11/01/250398.aspx)

	To achieve this, the 'throw' logic is moved out of the methods and is replaced by a call to the static 
	Throw class. All methods that never would be a candidate for inlining (because it was impossible to 
	reach the 32 bytes limit), but were interesting to optimize, were refactored in such a way that they 
	only call methods that on their turn would be inlined by the JIT compiler. Methods that can not be
	inlined are marked with an special attribute. There is a unit test that checks unmarked methods on their
	size. This way changes to method size will get noticed. Note that this unit test will only run in Release
	mode, because methods tend to be bigger in debug mode.

	*The .NET 3.5 SP1 will address with lack of inlining of structs.
	see: http://www.cuttingedge.it/blogs/steven/pivot/entry.php?id=34.
