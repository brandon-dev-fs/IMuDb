import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import Song from '../components/Song';

export default function AlbumDetails() {
	const params = useParams();
	const albumId = params.id;
	const [album, setAlbum] = useState(null);

	useEffect(() => {
		const ROOT_API = 'https://localhost:3001/api/';
		const url = `${ROOT_API}album/${albumId}`;

		fetch(url)
			.then((res) => res.json())
			.then((rData) => {
				setAlbum(rData);
			});
	}, []);

	return (
		album && (
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
	);
}
