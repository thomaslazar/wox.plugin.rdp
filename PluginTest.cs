using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Wox.Plugin.Rdp {
[TestFixture]
public class PluginTest {
	[Test]
	public void TestQuery() {
		Assert.AreEqual(1, new PuttyPlugin().Query(new Query("rdp")).Count);
        Assert.AreEqual(2, new PuttyPlugin().Query(new Query("rdp remotehost")).Count);

        List<Result> res = new PuttyPlugin().Query(new Query("rdp remotehost"));
	    Console.WriteLine("Results for: rdp remotehost");
		foreach (Result r in res) {
			Console.Out.WriteLine("Title: {0} Subtitle: {1}", r.Title, r.SubTitle);
		}
	}
}
// end namespace
}
