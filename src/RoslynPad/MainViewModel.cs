﻿using System;
using System.Collections.Generic;
using System.Composition;
using System.Reflection;
using RoslynPad.UI;
using System.Collections.Immutable;

namespace RoslynPad
{
    [Export(typeof(MainViewModelBase)), Shared]
    public class MainViewModel : MainViewModelBase
    {
        [ImportingConstructor]
        public MainViewModel(IServiceProvider serviceProvider, ITelemetryProvider telemetryProvider, ICommandProvider commands, IApplicationSettings settings, NuGetViewModel nugetViewModel) : base(serviceProvider, telemetryProvider, commands, settings, nugetViewModel)
        {
        }

        protected override IEnumerable<Assembly> CompositionAssemblies => ImmutableArray.Create(
            Assembly.Load(new AssemblyName("RoslynPad.Roslyn.Windows")),
            Assembly.Load(new AssemblyName("RoslynPad.Editor.Windows")));
    }
}