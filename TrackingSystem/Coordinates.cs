using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingSystem
{
    [FirestoreData]

    public class Coordinates

    {

        [FirestoreProperty]

        public string lat { get; set; }

        [FirestoreProperty]

        public string lng { get; set; }

    }
}
