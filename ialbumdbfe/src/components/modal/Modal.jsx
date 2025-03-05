import React from 'react';


export default function Modal({ modalToggle, modalContents }) {
    return (<>
        {
            modalToggle && (
                <div className="modal">
                    <div className="modal-content">
                        {modalContents}
                    </div>
                </div>
            )
        }
    </>);
}