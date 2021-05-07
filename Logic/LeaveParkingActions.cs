using SpaceApi.Models;
using System;

namespace Logic
{
    public class LeaveParkingActions
    {
        public void LeavePark(SpacePort spacePort)
        {
            var parkingCheck = new ParkingChecks();
            var payment = new PaymentActions();
            string name = StandardMessages.NameReader();
            var parkings = parkingCheck.ParkingLots(spacePort.PortName); // Get all parking lots in the spacePort
            var array = ArrayBuilder.OnLeaveArray(parkings);
            Console.Clear();
            var selectedOption = Menu.ShowMenu($"What ship will you be leaving with today?\n", array);

            var selectedParking = parkings.Result[selectedOption];
            if (selectedParking.Occupied == false) // If user selects a empty parking lot, display message
                StandardMessages.EmptyParkingLotMessage();
            else if (selectedParking.ParkedBy != name) // If user selects a ship that is not theirs, display message
                StandardMessages.NotYourShipMessage();
            else
            {
                payment.Pay(selectedParking); // Pay for the parking lot by getting the database row
                Leave(selectedParking); // Remove ship from database
            }
        }
        private void Leave(Parking park)
        {
            var spaceApi = new SpacePark.SpaceParkApi();
            park.Occupied = false;
            park.ParkedBy = null;
            park.ShipName = null;
            var result = spaceApi.Park(park);
            if (result.IsSuccessful)
            {
                Console.WriteLine("Left.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Something went wrong");
                Console.ReadKey();
            }
        }
    }
}
