using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;
using System.Text;
using System.Web.Script.Services;

namespace SuperHeroDB.Service
{
	
		[ServiceContract(Namespace = "")]
		[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
		public class SuperHeroService
		{
			//[OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json)]
			//public string DoWork()
			//{
			//    return "This is the SuperHeroDB service!";
			//}

			//Documents/VisualStudio2015/MyProjects

			[OperationContract]
			[WebGet(ResponseFormat = WebMessageFormat.Json)]
			public List<SuperHero> GetAllHeroes()
			{
				return Data.SuperHeroes;

			}

			[OperationContract]
			[WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetHero/{id}")]
			public SuperHero GetHero(string id)
			{
				return Data.SuperHeroes.Find(sh => sh.Id == int.Parse(id));

			}
		}
	}


