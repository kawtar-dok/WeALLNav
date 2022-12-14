//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeALLNav.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Demande_Navette_Clt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Demande_Navette_Clt()
        {
            this.Line_Demande = new HashSet<Line_Demande>();
        }
    
        public int Id_demande { get; set; }
        public int No_Client { get; set; }
        public int Num_Car { get; set; }
        public string Ville_Depart { get; set; }
        public string Ville_Arrivee { get; set; }
        public System.DateTime Date_Depart { get; set; }
        public System.DateTime Date_Arrivee { get; set; }
        public System.TimeSpan Heur_debut { get; set; }
        public System.TimeSpan Heur_fin { get; set; }
    
        public virtual Client Client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Line_Demande> Line_Demande { get; set; }
    }
}
