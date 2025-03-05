import React from 'react';
import { useNavigate } from 'react-router-dom';

export default function AlbumCard({ album }) {
    //For on click navigation
    const navigate = useNavigate();
    const navigateOnClick = (id) => {
        navigate(`/albums/${id}`);
    };

    return (
        <div className="card" onClick={() => navigateOnClick(album.id)}>
            <div className="card-title">
                <h2>
                    {album.name} <span>({album.year})</span>
                </h2>
            </div>
            <div className="card-body">
                <p>{album.artist.name}</p>
            </div>
        </div>
    );
}
