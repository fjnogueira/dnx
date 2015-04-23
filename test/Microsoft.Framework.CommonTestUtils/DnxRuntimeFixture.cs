using System;
using System.Collections.Generic;

namespace Microsoft.Framework.CommonTestUtils
{
    public class DnxRuntimeFixture : IDisposable
    {
        private IDictionary<Tuple<string, string, string>, DisposableDir> _runtimeDirs;

        public DnxRuntimeFixture()
        {
            Console.Write("{0} constructed.", nameof(DnxRuntimeFixture));

            _runtimeDirs = new Dictionary<Tuple<string, string, string>, DisposableDir>();
        }

        public virtual void Dispose()
        {
            foreach (var runtimeDir in _runtimeDirs.Values)
            {
                runtimeDir.Dispose();
            }

            Console.Write("{0} destructed.", nameof(DnxRuntimeFixture));
        }

        public string GetRuntimeHomeDir(string flavor, string os, string architecture)
        {
            var key = Tuple.Create(flavor, os, architecture);
            Console.WriteLine("{0}.{1} {2}", nameof(DnxRuntimeFixture), nameof(GetRuntimeHomeDir), key);

            DisposableDir runtimeDir;
            if (!_runtimeDirs.TryGetValue(key, out runtimeDir))
            {
                runtimeDir = TestUtils.GetRuntimeHomeDir(flavor, os, architecture);
                _runtimeDirs[key] = runtimeDir;

                Console.WriteLine("{0}.{1} create new runtime dir {2}", nameof(DnxRuntimeFixture), nameof(GetRuntimeHomeDir), runtimeDir.DirPath);
            }

            Console.WriteLine("{0}.{1} collection size {2}", nameof(DnxRuntimeFixture), nameof(GetRuntimeHomeDir), _runtimeDirs.Count);
            return runtimeDir.DirPath;
        }
    }
}
