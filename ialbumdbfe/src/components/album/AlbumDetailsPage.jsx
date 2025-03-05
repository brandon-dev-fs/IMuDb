import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { getAlbumById } from '../../services/httprequest';
import Song from '../song/Song';
import Loading from '../loading/loading';
import { useNavigate } from 'react-router-dom';

export default function AlbumDetailsPage() {
	const params = useParams();
	const albumId = params.id;
	const [loading, setLoading] = useState(true);
	const [error, setError] = useState(false);
	const [album, setAlbum] = useState({});
	//const [selectedSong, setSelectedSong] = useState(null);
	const navigate = useNavigate();
	const navigateOnClick = (id) => {
		navigate(`/artists/${id}`);
	};

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
		//setSelectedSong(song);
	}

	if (loading || error) {
		return (
			<div>
				{loading && <Loading />}
				{error && <h2>Error</h2>}
			</div>
		);
	} else {
		return (
			<div className="container">
				<div className="container-banner">
					<h1>{album.name}</h1>
				</div>
				<div className="container-body">
					<div className="details-contents">
						<div>
							<h3>Artist</h3>
							<span className="clickable" onClick={() => navigateOnClick(album.artist.id)}>{album.artist.name}</span>
							<h3>Year</h3>
							<span>{album.year}</span>
						</div>
						<div>
							<h3>Song List</h3>
							<ul>
								{album.songs.map((song) => (
									<li key={song.id} onClick={() => handleSelect(song)}>
										{song.track}. {song.name}
									</li>
								))}
							</ul>
						</div>
					</div>
					

				</div>

			</div>
		)
	}
}

//{
//	selectedSong && (
//		<Song albumId={albumId} /*song={selectedSong}*/ setSong={setSelectedSong} />
//	)
//}