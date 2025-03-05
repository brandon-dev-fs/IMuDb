const ROOT_API = 'https://localhost:3001/api/';

// Gets
//GET
//	/ api / Album X
const getAlbums = async () => {
    return fetch(`${ROOT_API}album`)
		.then(res => res.json())
        .catch(err => console.log(err));
}

//GET
//	/ api / Album / { albumId } X
const getAlbumById = async (albumId) => {
	return fetch(`${ROOT_API}album/${albumId}`)
		.then(res => res.json())
		.catch(err => console.log(err));
}

//GET
//	/ api / Album / { albumId } / song / { songId }
const getSongById = async (albumId, songId) => {
	return fetch(`${ROOT_API}album/${albumId}/song/${songId}`)
		.then(res => res.json())
		.catch(err => console.log(err));
}

//GET
//	/ api / Artist X
const getArtist = async () => {
	return fetch(`${ROOT_API}artist`)
		.then(res => res.json())
		.catch(err => console.log(err));
}

//GET
//	/ api / Artist / { artistId } X
const getArtistById = async (artistId) => {
	return fetch(`${ROOT_API}artist/${artistId}`)
		.then(res => res.json())
		.catch(err => console.log(err));
}

// Puts
//PUT
//	/ api / Album / { albumId } X
const updateAlbum = async (albumId, body) => {
	return fetch(`${ROOT_API}album/${albumId}`, {
		method: "Put",
		headers: {
			"Content-Type": "application/json",
		},
        body: JSON.stringify(body),
	})
	.then(res => res.json())
	.catch(err => console.log(err));
}
//PUT
//	/ api / Album / { albumId } / song / { songId }
const updateSong = async (albumId, songId, body) => {
	return fetch(`${ROOT_API}album/${albumId}/song/${songId}`, {
		method: "Put",
		headers: {
			"Content-Type": "application/json",
		},
		body: JSON.stringify(body),
	})
	.then(res => res.json())
	.catch(err => console.log(err));
}
//PUT
//	/ api / Artist / { artistId }
const updateArtist = async (artistId, body) => {
	return fetch(`${ROOT_API}artist/${artistId}`, {
		method: "Put",
		headers: {
			"Content-Type": "application/json",
		},
		body: JSON.stringify(body),
	})
	.then(res => res.json())
	.catch(err => console.log(err));
}

// Post
//POST
//	/ api / Album
const addAlbum = async (body) => {
	return fetch(`${ROOT_API}album`, {
		method: "Post",
		headers: {
			"Content-Type": "application/json",
		},
		body: JSON.stringify(body),
	})
	.then(res => res.json())
	.catch(err => console.log(err));
}

//POST
//	/ api / Artist
const addArtist = async (body) => {
	return fetch(`${ROOT_API}artist`, {
		method: "Post",
		headers: {
			"Content-Type": "application/json",
		},
		body: JSON.stringify(body),
	})
	.then(res => res.json())
	.catch(err => console.log(err));
}

// Deletes
//DELETE
//	/ api / Album / { albumId }
const deleteAlbum = async (albumId) => {
	return fetch(`${ROOT_API}album/${albumId}`, {
		method: "Delete"
	})
	.then(res => res.json())
	.catch(err => console.log(err));
}

//DELETE
//	/ api / Artist / { artistId }
const deleteArtist = async (artistId) => {
	return fetch(`${ROOT_API}artist/${artistId}`, {
		method: "Delete"
	})
	.then(res => res.json())
	.catch(err => console.log(err));
}

export {
	getAlbums,
	getArtist,
	getAlbumById,
	getSongById,
	getArtistById,
	updateAlbum,
	updateSong,
	updateArtist,
	addAlbum,
	addArtist,
	deleteAlbum,
	deleteArtist
}