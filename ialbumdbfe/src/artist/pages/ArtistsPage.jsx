import React from 'react';
import ArtistList from '../components/ArtistList';

class ArtistsPage extends React.Component {
	constructor(props) {
		super(props);

		this.state = {
			loading: true,
			error: false,
			artists: [],
			filteredArtist: [],
		};
	}

	async componentDidMount() {
		const ROOT_API = 'https://localhost:3001/api/';
		const url = `${ROOT_API}artist`;

		try {
			await fetch(url)
				.then((res) => res.json())
				.then((rData) => {
					//setArtists(rData);
					this.setState({
						loading: false,
						artists: rData,
						filteredArtist: rData,
					});
				});
		} catch (error) {
			console.log(error);
			this.setState({
				loading: false,
				error: true,
			});
		}
	}

	// When the search bar is updated to a new search term it updates the term value
	handleSearch = (e) => {
		const searchTerm = e.target.value.toLowerCase();
		const artists = this.state.artists;
		this.setState({
			filteredArtist: artists.filter((a) => {
				return a.name.toLowerCase().includes(searchTerm);
			}),
		});
	};

	render() {
		if (this.state.loading || this.state.error) {
			return (
				<div>
					{this.state.loading && <h2>Loading...</h2>}
					{this.state.error && <h2>Error</h2>}
				</div>
			);
		} else {
			return (
				<div className="container">
					{this.state.filteredArtist && (
						<>
							<div className="page-banner p-md">
								<h2>Artists</h2>
								<input
									className="search-bar"
									type="text"
									placeholder="Search Artist"
									onChange={this.handleSearch}
								/>
								<button className="button add-button">
									Add
								</button>
							</div>
							<div className="p-md">
								<ArtistList
									artists={this.state.filteredArtist}
								/>
							</div>
						</>
					)}
				</div>
			);
		}
	}
}

export default ArtistsPage;
