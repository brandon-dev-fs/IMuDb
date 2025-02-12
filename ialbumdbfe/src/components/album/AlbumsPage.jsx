import React, { useEffect, useState } from 'react';
import { getAlbums } from '../../services/httprequest';
import AlbumGrid from './AlbumGrid';

export default function AlbumsPage() {
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(false);
    const [albums, setAlbums] = useState([]);
    const [filteredAlbums, setFilteredAlbums] = useState([]);

    const handleSearch = (e) => {
        const searchTerm = e.target.value.toLowerCase();
        const newFilter = albums.filter((a) => {
            return a.name.toLowerCase().includes(searchTerm);
        });
        setFilteredAlbums(newFilter);
    };

    useEffect(() => {
        async function getData() {
            const retrievedAlbums = await getAlbums();

            console.log(retrievedAlbums)

            if (retrievedAlbums) {
                setLoading(false);
                setAlbums(retrievedAlbums);
                setFilteredAlbums(retrievedAlbums);
            }
            else {
                setLoading(false);
                setError(true);
            }
        }

        getData();

        console.log(filteredAlbums)
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
                {filteredAlbums && (
                    <>
                        <div className="page-banner p-md">
                            <h2>Albums</h2>
                            <input
                                className="search-bar"
                                type="text"
                                placeholder="Search Albums"
                                onChange={handleSearch}
                            />
                            <button className="button add-button">
                                Add
                            </button>
                        </div>
                        <div className="p-md">
                            <AlbumGrid albums={filteredAlbums}></AlbumGrid>
                        </div>
                    </>
                )}
            </div>
        );
    }
}