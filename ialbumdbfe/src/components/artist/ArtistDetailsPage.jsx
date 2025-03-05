import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { getArtistById } from '../../services/httprequest';
import Loading from '../loading/loading';
import { useNavigate } from 'react-router-dom';

export default function ArtistDetailsPage() {
    const params = useParams();
    const artistId = params.id;
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(false);
    const [artist, setArtist] = useState({});

    const navigate = useNavigate();
    const navigateOnClick = (id) => {
        navigate(`/albums/${id}`);
    };

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
            {loading && <Loading />}
            {error && <h2>Error</h2>}
        </div>
        );
    } else {
        return (<div className="container">
            <div className="container-banner">
                <h2>{artist.name}</h2><span>({artist.type === 0 ? "Solo" : "Band"})</span>
            </div>
            <div className="container-body">
                <div className="details-contents">
                    <div>
                        <h3>Musicians</h3>
                        {artist.musicians && (
                            <ul>
                                {artist.musicians.map((m, i) => (
                                    <li key={i}>{m}</li>
                                ))}
                            </ul>
                        )}
                    </div>
                    <div>
                        <h3>Albums</h3>
                        {artist.albums.length > 0 && (
                            <ul>
                                {artist.albums.map((a) => (
                                    <li className="clickable" key={a.id} onClick={() => navigateOnClick(a.id)} >
                                        {a.name} ({a.year})
                                    </li>
                                ))}
                            </ul>
                        )}
                    </div>
                </div>
            </div>
        </div>)
    }
}