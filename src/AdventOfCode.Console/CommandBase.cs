using System;
using System.Reflection;
using ManyConsole;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace Lazy.Macro.Console
{
	public abstract class CommandBase : ConsoleCommand
	{
		private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
		protected bool Verbose { get; set; }

		protected CommandBase()
		{
			HasOption("v|verbose", "Verbose output", b => Verbose = false);
		}

		public override int Run(string[] remainingArguments)
		{
			if (Verbose) AddNLogConsoleOutput();
			try
			{
				RunCommand(remainingArguments);
			}
			catch (Exception e)
			{
				_log.Error(e.Message, e);
				System.Console.Error.WriteLine(e.Message);
				return 1;
			}
			return 0;
		}

		protected abstract void RunCommand(string[] remainingArguments);

		private static void AddNLogConsoleOutput()
		{
			var repository = (Hierarchy)LogManager.GetRepository();
			var appender = new ConsoleAppender
				{
					Layout = new PatternLayout("%date %-5level  [%ndc] - %message%newline")
				};
			repository.Root.AddAppender(appender);
			repository.Configured = true;
			repository.RaiseConfigurationChanged(EventArgs.Empty);
			appender.Threshold = Level.Debug;
		}
	}
}