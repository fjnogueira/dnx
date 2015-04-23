// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace Microsoft.Framework.Runtime.Roslyn.Tests
{
    public class AfterCompileContextFacts
    {
        private AfterCompileContext _target;

        public AfterCompileContextFacts()
        {
            _target = new AfterCompileContext();
        }

        [Fact]
        public void DefaultConstructorSetAllPropertiesNull()
        {
            // nothing is set
            Assert.Null(_target.Compilation);
            Assert.Null(_target.Diagnostics);
            Assert.Null(_target.ProjectContext);
            Assert.Null(_target.AssemblyStream);
            Assert.Null(_target.SymbolStream);
            Assert.Null(_target.XmlDocStream);
        }

        [Fact]
        public void PropertyCompilationIsSettable()
        {
            var compilation = CSharpCompilation.Create("nothing");

            _target.Compilation = compilation;
            Assert.Equal(compilation, _target.Compilation);
        }
    }
}
