import React, { useEffect, useState } from 'react';
import { getArtist } from '../../services/httprequest';
import ArtistList from './ArtistList';

export default function ArtistsPage() {
	const [loading, setLoading] = useState(true);
	const [error, setError] = useState(false);
	const [artists, setArtists] = useState([]);
	const [filteredArtist, setFilteredArtist] = useState([]);

	// When the search bar is updated to a new search term it updates the term value
	const handleSearch = (e) => {
		const searchTerm = e.target.value.toLowerCase();
		const newFilter = artists.filter((a) => {
			return a.name.toLowerCase().includes(searchTerm);
		});
		setFilteredArtist(newFilter);
	};

	useEffect(() => {
		async function getData() {
			const retrievedArtists = await getArtist();

			console.log(retrievedArtists)

			if (retrievedArtists) {
				setLoading(false);
				setArtists(retrievedArtists);
				setFilteredArtist(retrievedArtists);
			}
			else {
				setLoading(false);
				setError(true);
			}
		}

		getData();

		console.log(filteredArtist)
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
				{filteredArtist && (
					<>
						<div className="page-banner p-md">
							<h2>Artists</h2>
							<input
								className="search-bar"
								type="text"
								placeholder="Search Artist"
								onChange={handleSearch}
							/>
							<button className="button add-button">
								Add
							</button>
						</div>
						<div className="p-md">
							<ArtistList
								artists={filteredArtist}
							/>
						</div>
					</>
				)}
			</div>
		);
	}
}