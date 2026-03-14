import { useState, useEffect } from "react";
import BowlerHeading from "./components/BowlerHeading";
import BowlerTable from "./components/BowlerTable";
import { Bowler } from "./models/Bowler";
import "./App.css";

function App() {
  const [bowlers, setBowlers] = useState<Bowler[]>([]);

  useEffect(() => {
    const fetchBowlers = async () => {
      try {
        const response = await fetch("http://localhost:5218/api/bowlers");
        if (!response.ok) {
          throw new Error("Failed to fetch bowlers");
        }
        const data = await response.json();
        setBowlers(data);
      } catch (error) {
        console.error("Error fetching bowlers:", error);
      }
    };

    fetchBowlers();
  }, []);

  return (
    <div className="App">
      <BowlerHeading />
      <BowlerTable bowlers={bowlers} />
    </div>
  );
}

export default App;
