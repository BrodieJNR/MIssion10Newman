import { useEffect, useState } from "react";
import type { Bowler } from "./models/Bowler";
import BowlerHeading from "./components/BowlerHeading";
import BowlerTable from "./components/BowlerTable";

function App() {
  const [bowlers, setBowlers] = useState<Bowler[]>([]);

  useEffect(() => {
    fetch("http://localhost:5034/api/bowlers")
      .then((response) => response.json())
      .then((data) => setBowlers(data))
      .catch((error) => console.error("Error fetching bowlers:", error));
  }, []);

  return (
    <div>
      <BowlerHeading />
      <BowlerTable bowlers={bowlers} />
    </div>
  );
}

export default App;