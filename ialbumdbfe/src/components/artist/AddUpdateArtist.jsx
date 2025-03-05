import React, { useState, useEffect } from 'react';
import { updateArtist, addArtist } from '../../services/httprequest';
import Modal from '../modal/Modal';

export default function AddUpdateArtistForm({ editArtist, modalToggle, setModalToggle }) {
    const [artist, setArtist] = useState({
        name: "",
        type: 0,
        musicians: []
    });

    const [newArtist, setNewArtist] = useState(true);
    const [musician, setMusician] = useState("");

    useEffect(() => {
        if (editArtist) {
            setArtist(editArtist);
            setNewArtist(false);
            setMusicians([...editArtist.members])
        }

        if (modalToggle) {

        }

    }, [modalToggle])

    const handleChange = (e) => {
        const { name, value } = e.target;
        setArtist((prevArtist) => ({ ...prevArtist, [name]: value }));
    }

    const handleSubmission = (e) => {
        e.preventDefault();

        console.log(artist);

        if (artist.type == 0) {
            setArtist((prevArtist) => ({
                ...prevArtist,
                musicians: []
            }));
        }

        if (editArtist) {
            updateArtist(artist.id, artist);
        }
        else {
            addArtist(artist);
        }

        console.log("submitted");

        cleanAndClose();
    }

    const handleAdd = () => {
        if (artist.type == 1) {
            setArtist((prevArtist) => ({
                ...prevArtist,
                musicians: [...prevArtist.musicians, musician]
            }));
        }

        setMusician("");
    }

    const cleanAndClose = () => {
        setArtist({
            name: "",
            type: 0,
            members: []
        });
        setModalToggle(false);
        if (newArtist === false) {
            setNewArtist(true);
        }
    }

    return (<>
        <Modal modalToggle={modalToggle}
            modalContents={(<>
                <div className="modal-header">
                    <h2 className="modal-title">
                        {newArtist ? 'Add New Artist' : 'Edit  {artist.name}'}
                        <span className="modal-close" onClick={() => cleanAndClose()}>
                            &times;
                        </span>
                    </h2>
                    
                </div>
                <form className="modal-body" onSubmit={handleSubmission}>
                    <div className="">
                        <label htmlFor="artist-name">Artist Name</label>
                        <input
                            type="text"
                            id="artist-name"
                            name="name"
                            value={artist.name}
                            placeholder="Enter an Artist Name"
                            onChange={e => setArtist((prevArtist) => ({ ...prevArtist, name: e.target.value }))}
                            required
                        />
                    </div>
                    <fieldset className="">
                        <legend>Artist Type</legend>
                        <input id="solo" name="type" type="radio" value={0} onChange={e => setArtist((prevArtist) => ({ ...prevArtist, type: 0 }))} defaultChecked={true} />
                        <label htmlFor="solo">Solo</label>
                        <br />
                        <input id="band" name="type" type="radio" value={1} onChange={e => setArtist((prevArtist) => ({ ...prevArtist, type: 1 }))} />
                        <label htmlFor="band">Band</label>
                    </fieldset>
                    {
                        artist.type == 1 && (
                            <fieldset className="">
                                <legend>Musicians</legend>
                                <input type="text" value={musician} placeholder="Add a musician" onChange={e => setMusician(e.target.value)} />
                                <button type="button" onClick={handleAdd}>Add</button>
                                <ul>
                                    {artist.musicians.map((m, i) => (
                                        <li key={i}>
                                            {m}
                                        </li>
                                    ))}
                                </ul>
                            </fieldset>
                        )
                    }
                    <div className="modal-footer">
                        <button type="submit">
                            {newArtist ? 'Add' : 'Update'}
                        </button>
                    </div>
                </form>
            </>
            )}
        />
    </>
    );
}