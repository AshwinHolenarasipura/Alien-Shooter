using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement.Planets
{
    [CreateAssetMenu(fileName = "Planets", menuName = "Planets/Create PlanetList", order = 1)]
    public class PlanetList : ScriptableObject
    {
        #region INSPECTOR
        [SerializeField] private List<PlanetSpecs> _planets;
        #endregion

        #region PROPERTIES
        public int TotalPlanets => _planets.Count;
        #endregion

        public PlanetSpecs GetPlanets(int index)
        {
            return _planets[index];
        }
    } 
}
