﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntryPoint
{
#if WINDOWS || LINUX
  public static class Program
  {
    [STAThread]
    static void Main()
    {
      var fullscreen = false;
      read_input:
      switch (Microsoft.VisualBasic.Interaction.InputBox("Which assignment shall run next? (1, 2, 3, or q for quit)", "Choose assignment", VirtualCity.GetInitialValue()))
      {
        case "1":
          using (var game = VirtualCity.RunAssignment1(SortSpecialBuildingsByDistance, fullscreen))
            game.Run();
          break;
        case "2":
          using (var game = VirtualCity.RunAssignment2(FindSpecialBuildingsWithinDistanceFromHouse, fullscreen))
            game.Run();
          break;
        case "3":
          using (var game = VirtualCity.RunAssignment3(FindRoute, fullscreen))
            game.Run();
          break;
        case "4":
          //using (var game = VirtualCity.RunAssignment4(FindRoutesToAll, fullscreen))
            //game.Run();
            //We're not doing Floyd Warshall.
          break;
        case "q":
          return;
      }
      goto read_input;
    }

    //EXCERCISE 1 = DONE
    private static IEnumerable<Vector2> SortSpecialBuildingsByDistance(Vector2 house, IEnumerable<Vector2> specialBuildings)
    {
        Merge merge = new Merge(house, specialBuildings);
        merge.sort();
        return merge.getList();
    }

    //EXCERCISE 2 = DONE
    private static IEnumerable<IEnumerable<Vector2>> FindSpecialBuildingsWithinDistanceFromHouse(
      IEnumerable<Vector2> specialBuildings, 
      IEnumerable<Tuple<Vector2, float>> housesAndDistances)
    {
        //  housesAndDistances has the pos. of the house and a float that indicates the range to search in, GAME takes THIS range.
        //  specialBuildings is a list of all special buildings.
        TreeSearch tree = new TreeSearch(specialBuildings, housesAndDistances);
        tree.search();
        return tree.getResults();
    }

    //EXCERSIZE 3 = DONE
    private static IEnumerable<Tuple<Vector2, Vector2>> FindRoute(Vector2 startingBuilding, 
      Vector2 destinationBuilding, IEnumerable<Tuple<Vector2, Vector2>> roads)
    { 
      Dijkstra dijkstra = new Dijkstra(startingBuilding, destinationBuilding, roads);
      return dijkstra.result();
    }

    //WE'RE NOT DOING THIS ONE
    /*
    private static IEnumerable<IEnumerable<Tuple<Vector2, Vector2>>> FindRoutesToAll(Vector2 startingBuilding, 
      IEnumerable<Vector2> destinationBuildings, IEnumerable<Tuple<Vector2, Vector2>> roads)
    {

      List<List<Tuple<Vector2, Vector2>>> result = new List<List<Tuple<Vector2, Vector2>>>();
      foreach (var d in destinationBuildings)
      {
        var startingRoad = roads.Where(x => x.Item1.Equals(startingBuilding)).First();
        List<Tuple<Vector2, Vector2>> fakeBestPath = new List<Tuple<Vector2, Vector2>>() { startingRoad };
        var prevRoad = startingRoad;
        for (int i = 0; i < 30; i++)
        {
          prevRoad = (roads.Where(x => x.Item1.Equals(prevRoad.Item2)).OrderBy(x => Vector2.Distance(x.Item2, d)).First());
          fakeBestPath.Add(prevRoad);
        }
        result.Add(fakeBestPath);
      }
      return result;
    }
  */
  }
#endif
}
