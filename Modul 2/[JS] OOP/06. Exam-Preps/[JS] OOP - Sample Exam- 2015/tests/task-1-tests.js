// Generated by CoffeeScript 1.9.3
var expect, result;

expect = require('chai').expect;

result = require('../tasks/task-1')();

describe('Sample exam tests', function() {
  return describe('Players', function() {
    return describe('With valid input', function() {
      it('expect getPlayer to exist, to be a function and to take a single parameter', function() {
        expect(result.getPlayer).to.exist;
        expect(result.getPlayer).to.be.a('function');
        return expect(result.getPlayer).to.have.length(1);
      });
      it('expect getPlayer to return a new player instance, with provided name and generated id', function() {
        var name, player;
        name = 'Rock and roll';
        player = result.getPlayer(name);
        expect(player).to.exist;
        expect(player).to.be.an('object');
        expect(player.name).to.equal(name);
        return expect(player.id).to.exist;
      });
      it('expect player.addPlaylist() to exists, to be a function, to take a single parameter and to enable chaining', function() {
        var name, player, playlist, returnedPlayer;
        name = 'Rock and roll';
        player = result.getPlayer(name);
        playlist = result.getPlaylist(name);
        expect(player.addPlaylist).to.exist;
        expect(player.addPlaylist).to.be.a('function');
        expect(player.addPlaylist).to.have.length(1);
        returnedPlayer = player.addPlaylist(playlist);
        return expect(returnedPlayer).to.equal(player);
      });
      it('expect player.getPlaylistById() to return previously added playlist, when no other playlists', function() {
        var name, player, playlist, returnedPlaylist;
        name = 'Rock and Roll';
        player = result.getPlayer(name);
        playlist = result.getPlaylist(name);
        returnedPlaylist = player.addPlaylist(playlist).getPlaylistById(playlist.id);
        return expect(returnedPlaylist).to.equal(playlist);
      });
      it('expect player.getPlaylistById() to return previously added playlist, when there are other playlists', function() {
        var count, i, j, k, name, player, playlist, ref, ref1;
        name = 'Rock and Roll';
        player = result.getPlayer(name);
        playlist = result.getPlaylist(name);
        count = 5;
        for (i = j = 0, ref = count; 0 <= ref ? j <= ref : j >= ref; i = 0 <= ref ? ++j : --j) {
          player.addPlaylist(result.getPlaylist(name + i));
        }
        player.addPlaylist(playlist);
        for (i = k = 0, ref1 = count; 0 <= ref1 ? k <= ref1 : k >= ref1; i = 0 <= ref1 ? ++k : --k) {
          player.addPlaylist(result.getPlaylist(name + i));
        }
        return expect(player.getPlaylistById(playlist.id)).to.equal(playlist);
      });
      it('expect player.getPlaylistById() with id, not contianed in the player to return null, when there are other playlists and when there are no playlists at all', function() {
        var count, i, ids, invalidID, j, name, player, playlist, ref;
        name = 'Rock and Roll';
        player = result.getPlayer(name);
        expect(player.getPlaylistById(2)).to.be["null"];
        count = 5;
        ids = {};
        for (i = j = 0, ref = count; 0 <= ref ? j <= ref : j >= ref; i = 0 <= ref ? ++j : --j) {
          playlist = result.getPlaylist(name + i);
          player.addPlaylist(playlist);
          ids[playlist.id] = true;
        }
        invalidID = (Math.random() * 100000000) | 0;
        while (ids[invalidID]) {
          invalidID = (Math.random() * 100000000) | 0;
        }
        return expect(player.getPlaylistById(invalidID)).to.be["null"];
      });
      return it('expect player.removePlaylist() to remove the playlist, when id is provided', function() {
        var i, j, name, player, playlist, results;
        name = 'Rock and Roll';
        player = result.getPlayer(name);
        playlist = result.getPlaylist(name);
        player.addPlaylist(playlist).removePlaylist(playlist.id);
        expect(player.getPlaylistById(playlist.id)).to.be["null"];
        results = [];
        for (i = j = 0; j <= 5; i = ++j) {
          results.push(player.addPlaylist(name + i));
        }
        return results;
      });
    });
  });
});

//# sourceMappingURL=task-1-tests.js.map
