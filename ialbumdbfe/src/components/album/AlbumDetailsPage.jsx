import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { getAlbumById } from '../../services/httprequest';
import Song from '../song/Song';

export default function AlbumDetailsPage() {
	const [loading, setLoading] = useState(true);
	const [error, setError] = useState(false);
	const params = useParams();
	const albumId = params.id;
	const [album, setAlbum] = useState(null);

	useEffect(() => {
		async function getData() {
			const retrievedAlbum = await getAlbumById(albumId);

			console.log(retrievedAlbum)

			if (retrievedAlbum) {
				setLoading(false);
				setAlbum(retrievedAlbum);
			}
			else {
				setLoading(false);
				setError(true);
			}
		}

		getData();
	}, []);

	if (loading || error) {
		return (
			<div>
				{loading && <h2>Loading...</h2>}
				{error && <h2>Error</h2>}
			</div>
		);
	} else {
		return (
			<div className="container">
				<div className="page-banner p-md">
					<h2>Album</h2>
					<h2>
						{album.name} ({album.year})
					</h2>
				</div>
				<div className="p-md">
					{album.songs.map((song) => (
						<Song key={song.id} song={song} />
					))}
				</div>
			</div>
		)
	}
}
