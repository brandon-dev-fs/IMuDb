import React, { useReducer } from 'react';

export default function AlbumsReducer(state, action) {
	switch (action.type) {
		case 'ADD_ALBUM':
			return { ...state };
		case 'EDIT_ALBUM':
			return { ...state };
		case 'CLEAR_EDITING_ALBUM':
			return { ...state };
		case 'DELETE_ALBUM':
			return { ...state };
		default:
			return state;
	}
}
