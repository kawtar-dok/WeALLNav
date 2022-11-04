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
    
    public partial class Navette
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Navette()
        {
            this.Line_Offre = new HashSet<Line_Offre>();
        }
    
        public int Id_abonnement { get; set; }
        public int No_Autocar { get; set; }
        public int No_Ste { get; set; }
        public System.DateTime Date_debut { get; set; }
        public System.DateTime Date_fin { get; set; }
        public System.TimeSpan Heur_debut { get; set; }
        public System.TimeSpan Heur_fin { get; set; }
        public string Ville_Depart { get; set; }
        public string Ville_Arriver { get; set; }
        public int Nbr_Max_Abonnee { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Line_Offre> Line_Offre { get; set; }
        public virtual Societe Societe { get; set; }
    }
}