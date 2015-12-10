using System;
using System.Collections.Generic;
using NDesk.Options;

namespace Lazy.Macro.Console
{
	/// <summary>
	///     Example implementation of a ManyConsole command-line argument parser
	///     (ConsoleCommand) class
	/// </summary>
	public class ExampleCommand : CommandBase
	{
		public string Argument1;
		public string Argument2;
		public bool BooleanOption;
		public string OptionalArgument1;
		public string OptionalArgument2;
		public List<string> OptionalArgumentList = new List<string>();

		#region Overrides of CommandBase

		protected override void RunCommand(string[] remainingArguments)
		{
			Argument1 = remainingArguments[0];
			Argument2 = remainingArguments[1];

			System.Console.WriteLine(@"Called Example command - Argument1 = ""{0}"" Argument2 = ""{1}"" BooleanOption: {2}",
			                         Argument1, Argument2, BooleanOption);

			OptionalArgumentList.ForEach(
				(item) => System.Console.WriteLine(@"List Item {0} = ""{1}""", OptionalArgumentList.IndexOf(item), item));

			if (BooleanOption)
			{
				throw new Exception("Throwing unhandled exception because BooleanOption is true");
			}
		}

		#endregion

		/// <summary>
		///     Configure command options and describe details in the class
		///     contructor
		/// </summary>
		/// <example>
		///     <para>Example usage:</para>
		///     <para>
		///         SampleConsole.exe example "option one" two -b -o "optional argument"
		///         -l=first -l=second -l "the third option"
		///     </para>
		///     <para>Expected output:</para>
		///     <para>
		///         Executing Example (Example implementation of a ManyConsole
		///         command-line argument parser Command): <see cref="Argument1" /> :
		///         option one <see cref="Argument2" /> : two <see cref="BooleanOption" />
		///         : True <see cref="OptionalArgument1" /> : optional argument
		///         <see cref="OptionalArgumentList" /> :
		///         System.Collections.Generic.List`1[System.String]
		///     </para>
		///     <para>
		///         Called Example command - <see cref="Argument1" /> = "option one"
		///         <see cref="Argument2" /> = "two" BooleanOptio n: True List Item 0 =
		///         "first" List Item 1 = "second" List Item 2 = "the third option"
		///     </para>
		/// </example>
		public ExampleCommand()
		{
			IsCommand("Example", "Example implementation of a ManyConsole command-line argument parser Command");

			HasOption("b|booleanOption", "Boolean flag option", b => BooleanOption = true);

			//  Setting .Options directly is the old way to do this, you may prefer to call the helper
			//  method HasOption/HasRequiredOption.
			Options = new OptionSet
				{
					{"l|list=", "Values to add to list", v => OptionalArgumentList.Add(v)},
					{
						"r|requiredArguments=", "Optional string argument requiring a value be specified afterwards",
						s => OptionalArgument1 = s
					},
					{
						"o|optionalArgument:", "Optional String argument which is null if no value follow is specified",
						s => OptionalArgument2 = s ?? "<no argument specified>"
					},
				};

			HasRequiredOption("requiredOption=", "Required string argument also requiring a value.", s => { });
			HasOption("anotherOptional=", "Another way to specify optional arguments", s => { });

			HasAdditionalArguments(2, "<Argument1> <Argument2>");
		}
	}
}