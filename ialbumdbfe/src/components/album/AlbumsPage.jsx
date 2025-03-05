import React, { useEffect, useState } from 'react';
import { getAlbums } from '../../services/httprequest';
import AlbumGrid from './AlbumGrid';
import Loading from '../loading/loading';
import SearchBar from '../searchbar/SearchBar'

export default function AlbumsPage() {
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(false);
    const [albums, setAlbums] = useState([]);
    const [filteredAlbums, setFilteredAlbums] = useState([]);

    //const handleSearch = (e) => {
    //    const searchTerm = e.target.value.toLowerCase();
    //    const newFilter = albums.filter((a) => {
    //        return a.name.toLowerCase().includes(searchTerm);
    //    });
    //    setFilteredAlbums(newFilter);
    //};

    useEffect(() => {
        getAlbums()
            .then(a => {
                console.log(a);
                setLoading(false);
                setAlbums(a);
                setFilteredAlbums(a);
            }).catch(e => {
                console.log(e);
                setLoading(false);
                setError(true);
            });
    }, []);

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
                {filteredAlbums && (
                    <>
                        <div className="container-banner">
                            <h2>Albums</h2>
                            <SearchBar placeholder="Search Albums" list={albums} setFilteredList={setFilteredAlbums} />
                            <button className="button add-button">
                                Add New Album
                            </button>
                        </div>
                        <div className="container-body">
                            <AlbumGrid albums={filteredAlbums}></AlbumGrid>
                        </div>
                    </>
                )}
            </div>
        );
    }
}