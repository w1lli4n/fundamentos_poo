namespace Payments
{
    public class Room
    {
        public Room(int seats)
        {
            this.Seats = seats;
            this.OcuppedSeats = 0;
        }

        protected int Seats { get; set; }
        private int OcuppedSeats;

        public void ReserveSeat()
        {
            OcuppedSeats++;

            if (OcuppedSeats >= Seats)
            {
                OnRoomSoldOut(EventArgs.Empty); // invocação do evento
            }
            else
            {
                Console.WriteLine("Seat reserved");
            }
        }

        public event EventHandler RoomSoldOutEvent; // criou um evento

        protected virtual void OnRoomSoldOut(EventArgs e)   // o event handler
        {
            EventHandler handler = RoomSoldOutEvent;    // liga o event handler com o evento
            handler?.Invoke(this, e);   // define o que será invocado
        }
    }
}