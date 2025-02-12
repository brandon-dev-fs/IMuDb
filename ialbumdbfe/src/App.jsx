import React from 'react';
import { Route, BrowserRouter as Router, Routes } from 'react-router-dom';
import AlbumDetailsPage from './components/album/AlbumDetailsPage';
import AlbumsPage from './components/album/AlbumsPage';
import ArtistDetailsPage from './components/artist/ArtistDetailsPage';
import ArtistsPage from './components/artist/ArtistsPage';
import Footer from './components/footer/Footer';
import Header from './components/header/Header';
import Home from './components/home/Home';
import './styles/styles.css';


function App() {
	return (
		<Router>
			<Header></Header>
			<div className="app">
				<Routes>
					<Route path="/" element={<Home />} />
					<Route path="/artists" element={<ArtistsPage />} />
					<Route path="/artists/:id" element={<ArtistDetailsPage />} />
					<Route path="/albums" element={<AlbumsPage />} />
					<Route path="/albums/:id" element={<AlbumDetailsPage />} />
				</Routes>
			</div>
			<Footer></Footer>
		</Router>
	);
}

export default App;
