const ROOT_API = 'https://localhost:3001/api/';

const getAlbums = async () => {
    return fetch(`${ROOT_API}album`)
		.then(res => res.json())
        .catch(err => console.log(err));
}

const getAlbumById = async (id) => {
	return fetch(`${ROOT_API}album/${id}`)
		.then(res => res.json())
		.catch(err => console.log(err));
}

const getArtist = async () => {
	return fetch(`${ROOT_API}artist`)
		.then(res => res.json())
		.catch(err => console.log(err));
}

const getArtistById = async (id) => {
	return fetch(`${ROOT_API}artist/${id}`)
		.then(res => res.json())
		.catch(err => console.log(err));
}


export { getAlbums, getArtist, getAlbumById, getArtistById }