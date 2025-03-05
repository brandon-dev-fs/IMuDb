import React, { useEffect, useState } from 'react';
import { getArtist } from '../../services/httprequest';
import ArtistList from './ArtistList';
import AddUpdateArtistForm from './AddUpdateArtist';
import Loading from '../loading/loading';
import SearchBar from '../searchbar/SearchBar'

export default function ArtistsPage() {
	const [loading, setLoading] = useState(true);
	const [error, setError] = useState(false);
	const [artists, setArtists] = useState([]);
	const [filteredArtist, setFilteredArtist] = useState([]);
	//const [editArtist, setEditArtist] = useState(null);
	const [modalToggle, setModalToggle] = useState(false)

	useEffect(() => {
		getArtist()
			.then(a => {
				console.log(a);
				setLoading(false);
				setArtists(a);
				setFilteredArtist(a);
			})
			.catch(e => {
                console.log(e);
				setLoading(false);
				setError(true);
			})

	}, [modalToggle]);

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
				{filteredArtist && (
					<>
						<div className="container-banner">
							<h2>Artists</h2>
							<SearchBar placeholder="Search Artist" list={artists} setFilteredList={setFilteredArtist} />
							<button type="button" onClick={() => setModalToggle(true)} className="button add-button">
								Add New Artist
							</button>
						</div>
						<div className="container-body">
							<ArtistList
								artists={filteredArtist}
							/>
						</div>
					</>
				)}
				<AddUpdateArtistForm modalToggle={modalToggle} setModalToggle={setModalToggle} />
			</div>
		);
	}
}