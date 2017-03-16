using System;
namespace AppJeuTetris
{
    /// <summary>
    /// Fournit les fonctionnalités d'un point.
    /// </summary>
    public interface IPoint
    {
        int Colonne { get; set; }
        int Rangée { get; set; }
    }
}
