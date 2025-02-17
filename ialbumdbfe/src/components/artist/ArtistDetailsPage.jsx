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
        getArtistById(artistId)
            .then(a => {
                console.log(a);
                setLoading(false);
                setArtist(a);
            })
            .catch(e => {
                console.log(e)
                setLoading(false);
                setError(true);
            });
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
                {artist.musicians && (
                    <div className="p-sm">
                        <h3>Musicians</h3>
                        {artist.musicians.map((m, i) => (
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