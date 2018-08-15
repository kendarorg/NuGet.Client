// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using NuGet.Common;
using NuGet.Configuration;
using System.Threading;

namespace NuGet.CommandLine.XPlat
{
    public class ListPackageArgs
    {
        public ILogger Logger { get; }
        public string Path { get; set; }
        public IEnumerable<PackageSource> PackageSources { get; set; }
        public IEnumerable<string> Frameworks { get; set; }
        public bool IncludeOutdated { get; set; }
        public bool IncludeDeprecated { get; set; }
        public bool IncludeTransitive { get; set; }
        public bool Prerelease { get; set; }
        public bool HighestPatch { get; set; }
        public bool HighestMinor { get; set; }
        public CancellationToken CancellationToken { get; set; }

        /// <summary>
        /// A constructor for the arguments of list package
        /// command. This is used to execute the runner's
        /// method
        /// </summary>
        /// <param name="path"> The path to the solution or project file </param>
        /// <param name="packageSources"> The sources for the packages to check in the case of --outdated </param>
        /// <param name="frameworks"> The user inputed frameworks to look up for their packages </param>
        /// <param name="includeOutdated"> Bool for --outdated present </param>
        /// <param name="includeDeprecated"> Bool for --deprecated present </param>
        /// <param name="includeTransitive"> Bool for --include-transitive present </param>
        /// <param name="prerelease"> Bool for --include-prerelease present </param>
        /// <param name="highestPatch"> Bool for --highest-patch present </param>
        /// <param name="highestMinor"> Bool for --highest-minor present </param>
        /// <param name="logger"></param>
        /// <param name="cancellationToken"></param>
        public ListPackageArgs(
            string path,
            IEnumerable<PackageSource> packageSources,
            IEnumerable<string> frameworks,
            bool includeOutdated,
            bool includeDeprecated,
            bool includeTransitive,
            bool prerelease,
            bool highestPatch,
            bool highestMinor,
            ILogger logger,
            CancellationToken cancellationToken)
        {
            Path = path ?? throw new ArgumentNullException(nameof(path));
            PackageSources = packageSources ?? throw new ArgumentNullException("source");
            Frameworks = frameworks ?? throw new ArgumentNullException("framework");
            IncludeOutdated = includeOutdated;
            IncludeDeprecated = includeDeprecated;
            IncludeTransitive = includeTransitive;
            Prerelease = prerelease;
            HighestPatch = highestPatch;
            HighestMinor = highestMinor;
            Logger = logger ?? throw new Exception("Logger cannot be null");
            CancellationToken = cancellationToken;
        }
    }
}