![Icon](https://i.imgur.com/XSacNPD.png?2)
## Conditions [![Build status](https://ci.appveyor.com/api/projects/status/09c4fnv2ov54vpwm?svg=true)](https://ci.appveyor.com/project/ghuntley/conditions)

Conditions is cross platform portable class library that helps developers to write pre- and postcondition validations in a fluent manner. Writing these validations is easy and it improves the readability and maintainability of code.

## Supported Platforms
* .NET 4.5 (We are now a Portable Class Library)
* Mono 
* Xamarin.iOS
* Xamarin.Android
* Xamarin.Mac

## Installation

Installation is done via NuGet:

    Install-Package Conditions


## Usage

Class documentation is available at https://ghuntley.github.io/Conditions

    public ICollection GetData(Nullable<int> id, string xml, IEnumerable<int> col)
    {
        // Check all preconditions:
        Condition.Requires(id, "id")
            .IsNotNull()          // throws ArgumentNullException on failure
            .IsInRange(1, 999)    // ArgumentOutOfRangeException on failure
            .IsNotEqualTo(128);   // throws ArgumentException on failure

        Condition.Requires(xml, "xml")
            .StartsWith("<data>") // throws ArgumentException on failure
            .EndsWith("</data>") // throws ArgumentException on failure
            .Evaluate(xml.Contains("abc") || xml.Contains("cba")); // arg ex

        Condition.Requires(col, "col")
            .IsNotNull()          // throws ArgumentNullException on failure
            .IsEmpty()            // throws ArgumentException on failure
            .Evaluate(c => c.Contains(id.Value) || c.Contains(0)); // arg ex

        // Do some work

        // Example: Call a method that should not return null
        object result = BuildResults(xml, col);

        // Check all postconditions:
        Condition.Ensures(result, "result")
            .IsOfType(typeof(ICollection)); // throws PostconditionException on failure

        return (ICollection)result;
    }
        
    public static int[] Multiply(int[] left, int[] right)
    {
        Condition.Requires(left, "left").IsNotNull();
        
        // You can add an optional description to each check
        Condition.Requires(right, "right")
            .IsNotNull()
            .HasLength(left.Length, "left and right should have the same length");
        
        // Do multiplication
    }
    
A particular validation is executed immediately when it's method is called, and therefore all checks are executed in the order in which they are written:

## With thanks to
* The icon "<a href="http://thenounproject.com/term/tornado/2706/" target="_blank">Tornado</a>" designed by <a href="http://thenounproject.com/adamwhitcroft/" target="_blank">Adam Whitcroft</a> from The Noun Project.
* With thanks to <a href="http://www.forgedoc.com/">ForgeDoc</a> for providing an open source license which is used to generate the class documentation.
* <a href="http://www.cuttingedge.it/">S. van Deursen</a> who is the original author of "<a href="https://conditions.codeplex.com/">CuttingEdge.Conditions</a>" from which this project was forked from.
