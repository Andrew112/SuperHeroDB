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
			return Data.SuperHeroes.Find(sh => sh.id == int.Parse(id));

		}

		[OperationContract]
		[WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
			UriTemplate = "AddHero", Method = "POST")]
		public SuperHero AddHero(SuperHero hero)    //object "hero"
		{
			hero.id = Data.SuperHeroes.Max(sh => sh.id) + 1;
			Data.SuperHeroes.Add(hero);
			return hero;

		}


		[OperationContract]
		[WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
			UriTemplate = "editHero", Method = "PUT")]
		public SuperHero PutHero(SuperHero hero)    //object "hero"
		{
			hero.id = Data.SuperHeroes.Max(sh => sh.id) + 1;
			Data.SuperHeroes.Add(hero);
			return hero;

		}

		[OperationContract]
		[WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
			UriTemplate = "UpdateHero/{id}", Method = "PUT")]
		public SuperHero UpdateHero(SuperHero updateHero, string id)
		{
			SuperHero hero = Data.SuperHeroes.Where(sh => sh.id == int.Parse(id)).FirstOrDefault();

			hero.FirstName = updateHero.FirstName;
			hero.LastName = updateHero.LastName;
			hero.HeroName = updateHero.HeroName;
			hero.PlaceOfBirth = updateHero.PlaceOfBirth;
			hero.Combat = updateHero.Combat;

			return hero;

		}
		

		[OperationContract]
		[WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
			UriTemplate = "DeleteHero/{id}", Method = "DELETE")]
		public List<SuperHero> DeleteHero(string id)
		{
			Data.SuperHeroes = Data.SuperHeroes.Where(sh => sh.Id != int.Parse(id)).ToList();

			return Data.SuperHeroes;

}
	}


