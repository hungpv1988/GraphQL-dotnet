using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(GraphQL.GraphiQL.Startup))]

namespace GraphQL.GraphiQL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
/*
query getHuman($idValue:String!){
  human(id:$idValue){
    __typename
    name
    homePlanet
    appearsIn
    friends{
      name
    }
  }
}

    query getDroid($id:String!){
  human(id:$id){
    name
    appearsIn
    friends{
      name
    }
  }
}
     */
