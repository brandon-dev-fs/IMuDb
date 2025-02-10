import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';

export default function ArtistDetails() {
	const params = useParams();
	const artistId = params.id;
	const [artist, setArtist] = useState(null);

	useEffect(() => {
		const ROOT_API = 'https://localhost:3001/api/';
		const url = `${ROOT_API}artist/${artistId}`;

		try {
			fetch(url)
				.then((res) => res.json())
				.then((rData) => {
					setArtist(rData);
				});
		} catch (error) {
			console.log(error);
		}
	}, []);

	return (
		artist && (
			<div className="container">
				<div className="page-banner p-md">
					<h2>Artist</h2>
					<h2>{artist.name}</h2>
				</div>
				<div className="flex-container p-md">
					{artist.members && (
						<div className="p-sm">
							<h3>Members</h3>
							{artist.members.map((m, i) => (
								<p key={i}>{m}</p>
							))}
						</div>
					)}
					{artist.albums.length > 0 && (
						<div className="p-sm">
							<h3>Albums</h3>
							{artist.albums.map((a) => (
								<p key={a.id}>
									{a.name} ({a.year})
								</p>
							))}
						</div>
					)}
				</div>
			</div>
		)
	);
}
