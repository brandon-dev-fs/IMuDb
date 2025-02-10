import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Footer from './general/components/Footer';
import Header from './general/components/Header';
import Home from './general/pages/Home';
import AlbumDetails from './album/pages/AlbumDetails';
import ArtistDetails from './artist/pages/ArtistDetails';
import AlbumsPage from './album/pages/AlbumsPage';
import ArtistsPage from './artist/pages/ArtistsPage';
import AddUpdateArtistForm from './artist/forms/AddUpdateArtist';
import './styles/styles.css';

function App() {
	return (
		<Router>
			<Header></Header>
			<div className="app">
				<Routes>
					<Route path="/" element={<Home />} />
					<Route path="/artists" element={<ArtistsPage />} />
					<Route path="/artists/:id" element={<ArtistDetails />} />
					<Route
						path="/artist-edit"
						element={<AddUpdateArtistForm />}
					/>
					<Route path="/albums" element={<AlbumsPage />} />
					<Route path="/albums/:id" element={<AlbumDetails />} />
				</Routes>
			</div>
			<Footer></Footer>
		</Router>
	);
}

export default App;
