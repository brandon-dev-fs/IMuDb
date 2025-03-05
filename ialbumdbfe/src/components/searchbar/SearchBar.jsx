import React, { useState } from 'react';

// Search Bar takes a placeholder a master list and a state update function for a filtered list
export default function SearchBar({ placeholder, list, setFilteredList }) {

	//const [filteredList, setFilteredList] = useState(filteredList);

	//useEffect(() => {
	//	setFilteredList(filteredList)
	//}, [])

	// When the search bar is updated to a new search term it updates the term value
	const handleSearch = (e) => {
		const searchTerm = e.target.value.toLowerCase();
		const newList = list.filter((a) => {
			return a.name.toLowerCase().includes(searchTerm);
		});
		setFilteredList(newList);
	};



	return (
		<div className="searchbar" >
			<label for="search" className="search-icon"></label>
			<input
				id="search"
				className="search"
				type="search"
				placeholder={placeholder}
				onChange={handleSearch}
			/>
		</div>)
}