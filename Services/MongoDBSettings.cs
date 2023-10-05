using System;
using Restful_APi.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Restful_APi.Services;
    public class MongoDBService
    {
        private readonly IMongoCollection<Playlist> _playlistCollection;
    }