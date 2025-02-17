import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { getAlbumById } from '../../services/httprequest';
import Song from '../song/Song';

export default function AlbumDetailsPage() {
	const params = useParams();
	const albumId = params.id;
	const [loading, setLoading] = useState(true);
	const [error, setError] = useState(false);
	const [album, setAlbum] = useState(null);
    const [selectedSong, setSelectedSong] = useState(null);

	useEffect(() => {
		getAlbumById(albumId)
			.then(a => {
				console.log(a);
				setLoading(false);
				setAlbum(a);
			}).catch(e => {
				console.log(e);
				setLoading(false);
				setError(true);
			});
	}, []);

	const handleSelect = (song) => {
		console.log("clicked")
		setSelectedSong(song);
	}

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
					<ul>
						{album.songs.map((song) => (
							<li key={ song.id } onClick={() => handleSelect(song)}>
								{song.track} {song.name} 
							</li>
						))}
					</ul>
				</div>
				{selectedSong && (
					<Song albumId={albumId} song={selectedSong} setSong={setSelectedSong} />
				)}
			</div>
		)
	}
}
