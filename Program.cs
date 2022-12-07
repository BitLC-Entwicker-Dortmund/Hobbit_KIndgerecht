using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hobbit_KIndgerecht {

    delegate void RingHandler ();
    
    class Program {
        static void Main ( string [] args ) {
            Hobbit frodo = new Hobbit () { Name = "Frodo" , IsSichtbar = true };
            frodo.GefahrExistent += frodo.RingAufsetzen;
            frodo.GefahrVorüber += frodo.RingAbnehmen;
            frodo.leben ();

            Console.Read ();
        }
    }
    class Hobbit {
        public string Name { get; set; }
        public bool IsSichtbar { get; set; }
        public event RingHandler GefahrExistent;
        public event RingHandler GefahrVorüber;

        public void RingAufsetzen() {
            IsSichtbar = false;

            Console.WriteLine ("Nicht sichtbar - G E F A H R");
        }

        public void RingAbnehmen () {
            IsSichtbar = true;
            Console.WriteLine ("Sichtbar - Erlebe Abenteuer");
        }

        public void leben () {
            for ( int i = 0 ; i < 200 ; i++ ) {
                if ( i % 9 == 0 ) {      // an Stelle eines Zufallsgenarators
                    GefahrExistent ();
                }
                if ( i % 7 == 0 ) {     // an Stelle eines Zufallsgenarators
                    GefahrVorüber ();
                }
                Thread.Sleep ( 50 );
            }
        }
    }
}
