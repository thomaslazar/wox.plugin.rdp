using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Wox.Plugin.Rdp
{
	
	public class PuttyPlugin: IPlugin
	{
		private PluginInitContext context;
		
		public void Init(PluginInitContext context)
		{
			this.context = context;
		}
		
		public List<Result> Query(Query query)
		{
			List<Result> results = new List<Result>();

		    if (query.ActionParameters.Count != 0)
		        results.Add(MakeResult(query.ActionParameters[0], null));

			results.Add(MakeResult(null, null));

			return results;			
		}

		private Result MakeResult(string name, string desc)
		{
			return new Result() {
				Title = name ?? "Remote Desktop Connection",
				SubTitle = desc ?? "Launch Clean Remote Desktop Connection",
				IcoPath = "Images\\plugin.png",
				Action = e => {
					try {
						var p = new Process();
						p.StartInfo.FileName = "mstsc";
						if (name != null) {
							p.StartInfo.Arguments = "/v:" + name;
						}
						p.Start();
					} catch (Exception ex) {
						context.ShowMsg.Invoke("Rdp Error: " + name, ex.Message, ""); 
						return false;
						// ignore exception
					}
					return true;
				}
			};
		}
	}
	// end namespace
}