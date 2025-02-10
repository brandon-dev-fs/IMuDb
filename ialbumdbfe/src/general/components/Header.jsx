import Navbar from './Navbar';
import logo from '../../assets/logo/IMuDBRecordLogo.svg';

export default function Header() {
	return (
		<div className="header">
			<img
				className="logo"
				alt="Logo for Internet Music Database"
				src={logo}
			/>
			<Navbar />
		</div>
	);
}
