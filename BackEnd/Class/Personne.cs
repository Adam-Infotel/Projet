using System.ComponentModel.DataAnnotations;  // Pour les annotations
using System.ComponentModel.DataAnnotations.Schema;  // Pour les annotations sur la base de données
using System;
using System.Collections.Generic;

namespace BackEnd.Class
{
    [Table("personne")]  
    public class Personne
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le username est requis.")]
        [StringLength(100, ErrorMessage = "Le prénom ne peut pas dépasser 100 caractères.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Le username ne doit contenir que des lettres et des espaces.")]
        public string Username { get; set; }

        // Prénom de la personne
        [Required(ErrorMessage = "Le prénom est requis.")]
        [StringLength(100, ErrorMessage = "Le prénom ne peut pas dépasser 100 caractères.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Le prénom ne doit contenir que des lettres et des espaces.")]
        public string Prenom { get; set; }

        // Nom de la personne
        [Required(ErrorMessage = "Le nom est requis.")]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Le nom ne doit contenir que des lettres et des espaces.")]
        public string Nom { get; set; }

        // Mot de passe de la personne
        [Required(ErrorMessage = "Le mot de passe est requis.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Le mot de passe doit comporter au moins 6 caractères.")]
        public string MotDePasse { get; set; }

        // Numéro de téléphone
        [Phone(ErrorMessage = "Le numéro de téléphone n'est pas valide.")]
        public string? Telephone { get; set; }

        // Email de la personne
        [EmailAddress(ErrorMessage = "L'adresse email n'est pas valide.")]
        [Required(ErrorMessage = "L'email est requis.")]
        public string Email { get; set; }

        // Adresse de la personne
        [StringLength(200, ErrorMessage = "L'adresse ne peut pas dépasser 200 caractères.")]
        public string? Adresse { get; set; }

        // Ville de la personne
        [StringLength(100, ErrorMessage = "Le nom de la ville ne peut pas dépasser 100 caractères.")]
        public string? Ville { get; set; }

        // Code postal de la personne
        [StringLength(10, ErrorMessage = "Le code postal ne peut pas dépasser 10 caractères.")]
        public string? CodePostal { get; set; }

        // Pays de la personne
        [StringLength(100, ErrorMessage = "Le pays ne peut pas dépasser 100 caractères.")]
        public string? Pays { get; set; }

        // Date de naissance de la personne
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1/1/1900", "1/1/2023", ErrorMessage = "La date de naissance doit être entre le 1er janvier 1900 et le 1er janvier 2023.")]
        public DateTime? DateNaissance { get; set; }

        // Indicateur si la personne est connectée
        public bool IsConnected { get; set; }

        // Date de la dernière connexion de la personne
        public DateTime? LastConnexion { get; set; }
    }
}
