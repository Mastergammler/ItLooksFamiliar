using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItLooksFamiliar.Items
{

    public class ShipTester : MonoBehaviour
    {
        public string CoolingErrorMessage;
        public string CoreErrorMessage;
        public string SpaceTimeErrorMessage;
        public string CircuitErrorMessage;
        public string AntennaErrorMessage;
        public string RepairSuccessfullMessage;

        public string GetErrorMessage(Errors errorType)
        {
            switch (errorType)
            {
                case Errors.COOLING_ERROR: return CoolingErrorMessage;
                case Errors.ISOLATION_ERROR: return CoreErrorMessage;
                case Errors.SPACE_TIME_COMP_ERROR: return SpaceTimeErrorMessage;
                case Errors.CRICUIT_ERROR: return CircuitErrorMessage;
                case Errors.ANTENNA_ERROR: return AntennaErrorMessage;
                default: return RepairSuccessfullMessage;
            }
        }
        public string GetErrorMessage(Errors errorType, RepairItems items) 
        {

            switch(errorType)
            {
                case Errors.COOLING_ERROR: return items.Cooling != null ? items.Cooling.ThermalError : "Item not present";
                case Errors.ISOLATION_ERROR: return items.Core != null ? items.Core.IsolationError:"Item not present";
                case Errors.SPACE_TIME_COMP_ERROR: return items.SpaceTimeComp != null ? items.SpaceTimeComp.PressureError:"Item not present";
                case Errors.CRICUIT_ERROR: return items.Circuit != null ? items.Circuit.ConductivityError:"Item not present";
                case Errors.ANTENNA_ERROR: return items.Antenna != null ? items.Antenna.VibrationError:"Item not present";
                case Errors.NO_ITEMS: return "More items required!";
                default: return RepairSuccessfullMessage;
            }
        }

        public static Errors TestShipFunction(RepairItems items)
        {
            //todo fix error, one right item = success
            if (items.Cooling != null && items.Cooling.ThermalConductivity < 8) return Errors.COOLING_ERROR;
            if (items.Core != null && items.Core.IsolationValue < 8) return Errors.ISOLATION_ERROR;
            if (items.SpaceTimeComp != null && items.SpaceTimeComp.PressureResistance < 8) return Errors.SPACE_TIME_COMP_ERROR;
            if (items.Circuit != null && items.Circuit.ElectricalConductivity < 8) return Errors.CRICUIT_ERROR;
            if (items.Antenna != null && items.Antenna.VibrationValue < 8) return Errors.ANTENNA_ERROR;
            if(items.Cooling != null && items.Core != null && items.SpaceTimeComp != null && items.Circuit != null && items.Antenna != null) return Errors.NO_ERRORS;
            return Errors.NO_ITEMS;
        }
    }

    public enum Errors
    {
        COOLING_ERROR, ISOLATION_ERROR, SPACE_TIME_COMP_ERROR, CRICUIT_ERROR, ANTENNA_ERROR, NO_ERRORS, NO_ITEMS
    }

    public struct RepairItems
    {
        public RepairItems(CollectableSO cooling, CollectableSO core, CollectableSO spaceTimeComp, CollectableSO circuit, CollectableSO antenna)
        {
            Cooling = cooling;
            Core = core;
            SpaceTimeComp = spaceTimeComp;
            Circuit = circuit;
            Antenna = antenna;
        }

        public CollectableSO Cooling { get; }
        public CollectableSO Core { get; }
        public CollectableSO SpaceTimeComp { get; }
        public CollectableSO Circuit { get; }
        public CollectableSO Antenna { get; }
    }
}