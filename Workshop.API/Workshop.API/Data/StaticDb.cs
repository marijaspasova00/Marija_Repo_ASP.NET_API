using System.Collections.Generic;
using Workshop.API.Domain.Enums;
using Workshop.API.Domain.Models;

namespace Workshop.API.Data
{
    public static class StaticDb
    {
        public static List<Movie> Movies = new List<Movie>()
        {
            new Movie { Id = 1, Title = "Inception", Description = "A thief enters the dreams of others to steal their secrets.", Year = "2010", Genre = Genre.ScienceFiction | Genre.Thriller },
            new Movie { Id = 2, Title = "The Shawshank Redemption", Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", Year = "1994", Genre = Genre.Drama },
            new Movie { Id = 3, Title = "The Lord of the Rings: The Fellowship of the Ring", Description = "A young hobbit, Frodo, must journey to Mount Doom to destroy a powerful ring.", Year = "2001", Genre = Genre.Fantasy | Genre.Adventure },
            new Movie { Id = 4, Title = "Pulp Fiction", Description = "Various interconnected stories of crime, centered around two hitmen, a boxer, and a gangster's wife.", Year = "1994", Genre = Genre.Crime | Genre.Drama },
            new Movie { Id = 5, Title = "The Avengers", Description = "Superheroes team up to save the world from a powerful threat.", Year = "2012", Genre = Genre.Action | Genre.Superhero },
            new Movie { Id = 6, Title = "Finding Nemo", Description = "A clownfish embarks on a journey across the ocean to find his son.", Year = "2003", Genre = Genre.Animation | Genre.Family },
            new Movie { Id = 7, Title = "Jurassic Park", Description = "A billionaire invites a group of scientists to his amusement park, which is populated by cloned dinosaurs.", Year = "1993", Genre = Genre.ScienceFiction | Genre.Adventure },
            new Movie { Id = 8, Title = "The Social Network", Description = "The story of the creation and rise of the social media platform Facebook.", Year = "2010", Genre = Genre.Drama | Genre.Biography },
            new Movie { Id = 9, Title = "Harry Potter and the Sorcerer's Stone", Description = "A young wizard begins his journey at a magical school.", Year = "2001", Genre = Genre.Fantasy | Genre.Adventure },
            new Movie { Id = 10, Title = "The Dark Knight", Description = "Batman battles the Joker, a criminal mastermind wreaking havoc on Gotham City.", Year = "2008", Genre = Genre.Action | Genre.Crime }
        };
    }
}
