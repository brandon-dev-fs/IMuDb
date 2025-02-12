import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { getArtistById } from '../../services/httprequest';

export default function ArtistDetailsPage() {
    const params = useParams();
    const artistId = params.id;
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(false);
    const [artist, setArtist] = useState(null);

    useEffect(() => {
        async function getData() {
            const artist = await getArtistById(artistId);

            console.log(artist)

            if (artist) {
                setLoading(false);
                setArtist(artist);
            }
            else {
                setLoading(false);
                setError(true);
            }
        }

        getData();
    }, []);

    if (loading || error) {
        return (<div>
            {loading && <h2>Loading...</h2>}
            {error && <h2>Error</h2>}
        </div>
        );
    } else {
        return (<div className="container">
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
        </div>)
    }
}