using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class DEBUG__CONVEYOR_BELT : MonoBehaviour
{

	[Range(-1, 10)]
	public int state = 0;



	private void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			StopAllCoroutines();
			StartCoroutine(STIMULATE());
		}
	}


	public Camera cam;

	IEnumerator STIMULATE()
	{
		#region fame_rate
		QualitySettings.vSyncCount = 2;
		yield return null;
		yield return null;
		#endregion



		DRAW.dt = Time.deltaTime;

		// INITIALIZE_GRID with EMPTY tiles //
		STORE.dimension = new int[2] { 7, 7 };
		STORE.INITIALIZE();
		// INITIALIZE_GRID with EMPTY tiles //


		_INPUT_.cam = this.cam;




		STORE.UPDATE__CONVEYOR_BELT__CONFIGURATIONS__and__PATHS_CALCULATION();
		StartCoroutine(COROUTINE__MOVE_RESOURCES__WITHOUT_AFFECTING_INPUT());



		while (true)
		{
			/*
				DRAW.QUAD(V2(0, 0));
				DRAW.DIR(V2(0, 0), this.state);
			*/

			if(Input.GetMouseButtonDown(2))
			{
				LOG.FILE
				(
						LOG.conveyor_belt__1D(STORE.CONVEYOR_BELT__1D) + 
						"\n\n\n\n\n\n\n\n" +
						LOG.PATHS(STORE.PATHS)
				);
			}


			RENDER.RENDER__DRAW_TILES(STORE.GRID);

			// INPUT EVENTS //
			_INPUT_.EVENT(STORE.dimension);
			// INPUT EVENTS //


			yield return null;
		}

	}




	IEnumerator COROUTINE__MOVE_RESOURCES__WITHOUT_AFFECTING_INPUT()
	{
		while (true)
		{
			PATH.FUNCTIONALITY__MOVE_RESOURCES();

			for (int i0 = 0; i0 < 10; i0 += 1)
			{
				//
				RENDER.RENDER__DRAW_TILES(STORE.GRID);
				yield return null;
			}

			RENDER.RENDER__DRAW_TILES(STORE.GRID);
			yield return null;
		}



	}




	///// STUFF /////

	//
	/*
		EXPAND IN A WAY, WHERE A NEW TYPE OF TILE 
		COULD BE INCLUDED AMONG A TILE - TYPE
	*/









	public static class STORE
	{
		public static TILE[][] GRID;

		public static List<CONVEYOR_BELT> CONVEYOR_BELT__1D;
		public static List<MACHINE> MACHINE__1D;

		public static List<PATH> PATHS;


		public static int[] dimension;
		public static void INITIALIZE( )
		{
			CREATE_GRID();
		}


		public static void UPDATE__CONVEYOR_BELT__CONFIGURATIONS__and__PATHS_CALCULATION()
		{
			PATH.CALCULATE_each__CONVEYOR_BELT__CONFIGURAIONS__IN_ORDER();
			PATH.CALCULATE_each__PATH();
		}



		#region CREATE_GRID
		static void CREATE_GRID()
		{
			int w = dimension[0],
				h = dimension[1];

			STORE.GRID = new TILE[h][];
			for (int y = 0; y < h; y += 1)
			{
				GRID[y] = new TILE[w];

				for (int x = 0; x < w; x += 1)
				{
					//
					GRID[y][x] = new TILE()
					{
						TILE_TYPE = C.EMPTY__tile,
						TILE_INDEX_in_HOLDER = C.none
					};
					//
				}
			}


			CONVEYOR_BELT__1D = new List<CONVEYOR_BELT>();
			MACHINE__1D = new List<MACHINE>();
			PATHS = new List<PATH>();

		}
		#endregion




	}


	public class PATH
	{
		public List<CONVEYOR_BELT> belts;

		// TODO : circular path
		public int path_type;




		//// CALCULATION ////


		#region CALCULATION OF CONVEYOR_BELT IN ORDER
		public static void CALCULATE_each__CONVEYOR_BELT__CONFIGURAIONS__IN_ORDER()
		{

			for (int i0 = 0; i0 < STORE.CONVEYOR_BELT__1D.Count; i0 += 1)
			{
				CONVEYOR_BELT belt = STORE.CONVEYOR_BELT__1D[i0];
				belt.CALCULATE__linkage_type__enter_flow();
			}

			for (int i0 = 0; i0 < STORE.CONVEYOR_BELT__1D.Count; i0 += 1)
			{
				CONVEYOR_BELT belt = STORE.CONVEYOR_BELT__1D[i0];
				belt.CALCULATE__exit_flow();
			}


		}

		#endregion

		#region CALCUATION OF EACH PATH
		public static void CALCULATE_each__PATH()
		{
			STORE.PATHS = new List<PATH>();

			bool[] explored = new bool[STORE.CONVEYOR_BELT__1D.Count];

			#region INITIALIZE_explored
			for (int i0 = 0; i0 < STORE.CONVEYOR_BELT__1D.Count; i0 += 1)
			{
				//
				explored[i0] = false;
			}
			#endregion


			int iter_0 = 0;
			while (true)
			{
				iter_0 += 1;
				if(iter_0 > 1000) { Debug.Log("iter_0 .... stuck"); break; }

				#region Weather all_belts_explored ?
				bool all_belts_explored = true;

				for (int i0 = 0; i0 < explored.Length; i0 += 1)
				{
					//
					if (explored[i0] == false) { all_belts_explored = false; break; }
					//
				}

				if (all_belts_explored) { break; }
				#endregion


				CONVEYOR_BELT start_belt = null;


				int start_belt__index__to_calculate_circular_path = C.none;
				int path_type = C.linear_path;

				#region find a random not explored CONVEYOR_BELT__tile
				for (int i0 = 0; i0 < STORE.CONVEYOR_BELT__1D.Count; i0 += 1)
				{
					//
					if (!explored[i0])
					{
						start_belt = STORE.CONVEYOR_BELT__1D[i0];
						// explored //
						explored[i0] = true;
						// explored //

						start_belt__index__to_calculate_circular_path = i0;

						break;
					}
					//

				}
				#endregion


				#region find the start_belt of path // until enter is not CONVEYOR_BELT__tile
				int iter_1 = 0;
				while (true)
				{
					iter_1 += 1;
					if (iter_1 > 1000) { Debug.Log("iter_1 .... stuck"); break; }
					if (start_belt.enter_flow_type != C.CONVEYOR_BELT__flow)
						break;



					if(start_belt.enter_flow_TILE_index == start_belt__index__to_calculate_circular_path)
					{
						//
						start_belt = STORE.CONVEYOR_BELT__1D[start_belt.enter_flow_TILE_index];
						path_type = C.circular_path;
						break;
					}

					//
					start_belt = STORE.CONVEYOR_BELT__1D[start_belt.enter_flow_TILE_index];
				}

				#endregion



				PATH path = new PATH()
				{
					belts = new List<CONVEYOR_BELT>() { start_belt },
					path_type = path_type
				};
				//



				#region path from start_belt to end_belt

				CONVEYOR_BELT end_belt = start_belt;
				// 
				int iter_2 = 0;

				while (true)
				{
					iter_2 += 1;
					if (iter_2 > 1000) { Debug.Log("iter_2 .... stuck"); break; }


					if (path.path_type == C.circular_path)
					{
						if(end_belt.exit_flow_TILE_index == start_belt__index__to_calculate_circular_path)
						{
							break;
						}
						//

						// explored //
						// explored[end_belt.exit_flow_TILE_index] = true;
						// explored //

						end_belt = STORE.CONVEYOR_BELT__1D[end_belt.exit_flow_TILE_index];
						path.belts.Add(end_belt);
					}
					//

					else if (path.path_type == C.linear_path)
					{
						if (end_belt.exit_flow_type != C.CONVEYOR_BELT__flow)
						{
							break;
						}

						// explored //
						// explored[end_belt.exit_flow_TILE_index] = true;
						// explored //

						end_belt = STORE.CONVEYOR_BELT__1D[end_belt.exit_flow_TILE_index];
						path.belts.Add(end_belt);

					}
				}
				#endregion
				//
				STORE.PATHS.Add(path);



				foreach(CONVEYOR_BELT belt in path.belts)
				{
					explored[STORE.CONVEYOR_BELT__1D.IndexOf(belt)] = true;
				}



				string str = "";
				for(int i0 = 0; i0 < explored.Length; i0 += 1)
				{
					str += explored[i0] + " - ";
				}
				Debug.Log(str);

			}







		}

		#endregion

		//// CALCULATION ////





		//// FUNCTIONALITY ////

		#region FUNCTIONALITY__MOVE_RESOURCES
		/*
			transfer payload from end_belt to the MACHINE(if exist)
			move the payload on CONVEYOR_BELT in the along the path
		*/


		public static void FUNCTIONALITY__MOVE_RESOURCES()
		{
			for (int i0 = 0; i0 < STORE.PATHS.Count; i0 += 1)
			{
				PATH path = STORE.PATHS[i0];


				// circular_move
				if (path.path_type == C.circular_path) { circular_move(path); return; }





				// linear__move

				CONVEYOR_BELT end_belt = path.belts[path.belts.Count - 1];
				//
				if (end_belt.exit_flow_TILE_index == C.MACHINE__flow)
				{
					STORE.MACHINE__1D[end_belt.exit_flow_TILE_index]
						.LET_1D[end_belt.exit_flow_TILE_LET_index]
						.payload = end_belt.payload;

					//
					end_belt.payload = C.none__payload;
				}


				for (int i1 = path.belts.Count - 2; i1 >= 0; i1 -= 1)
				{
					if (path.belts[i1 + 1].payload == C.none__payload)
					{
						path.belts[i1 + 1].payload = path.belts[i1].payload;
						path.belts[i1].payload = C.none__payload;
					}
				}




				//
			}
		}

		#endregion


		#region ad
		public static void circular_move(PATH path)
		{
			// minimum 4 tiles to be circular path

			int start_belt__payload = path.belts[0].payload;
			path.belts[0].payload = C.none__payload;
			
			for(int i0 = path.belts.Count - 1; i0 >= 1; i0 -= 1)
			{
				path.belts[(i0 + 1) % path.belts.Count].payload = path.belts[i0].payload;
				path.belts[i0].payload = C.none__payload;
			}

			path.belts[1].payload = start_belt__payload;


		}
		#endregion


		//// FUNCTIONALITY ////

	}




	public class TILE
	{
		/*
			CONVEYOR_BELT
			EMPTY
			NONE

			TODO : MACHINE
			TODO : NATURAL_RESOURCE
		*/
		public int TILE_TYPE = C.EMPTY__tile;
		public int TILE_INDEX_in_HOLDER = C.none;
	}


	//

	public class CONVEYOR_BELT
	{

		public int state_of_tile;                            // r , f , l , b [absolute]
		public int linkage_type;                             // r_to_f , l_to_f , b_to_f  [relative to state of tile]


		public int enter_flow_type;                          // CONVEYOR_BELT , MACHINE , none
		public int exit_flow_type;                           // CONVEYOR_BELT , MACHINE , none 


		public int enter_flow_TILE_index;                    // index in L<>
		public int enter_flow_TILE_LET_index;                // index in L<LET> (if enter_flow_type = MACHINE)


		public int exit_flow_TILE_index;                     // index in L<>
		public int exit_flow_TILE_LET_index;                 // index in L<LET> (if exit_flow_type = MACHINE)



		public int[] global_pos;                             // v2 global

		public int payload;                                  // resource_type , none






		#region // METHID - 0 //

		public void CLASSIFY__linkage_type()
		{
			// using state_of_tile , C.DIRS // local : f , l , b , r
			int[] state_of_tile__neighbour__1D = new int[4];


			// TODO
			// int[] tile_let_index_of_machine_tile = new int[4] { C.none, C.none, C.none, C.none };


			// STORE //
			for (int i0 = 0; i0 < 4; i0 += 1)
			{
				int[] dir = C.DIRS[(this.state_of_tile + i0) % 4];

				int[] pos = new int[2]
				{
					this.global_pos[0] + dir[0],
					this.global_pos[1] + dir[1],
				};


				TILE tile = STORE.GRID[pos[1]][pos[0]];




				if (tile.TILE_TYPE == C.CONVEYOR_BELT__tile)
					state_of_tile__neighbour__1D[i0] = STORE.CONVEYOR_BELT__1D[tile.TILE_INDEX_in_HOLDER].state_of_tile;
				//
				else if (tile.TILE_TYPE == C.MACHINE__tile)
				{
					// TODO
					// based on one of inlet , outlet associated with curr tile, tile state shall be : r , f , l , b __state
					// or else its a none__state

					//store the let index of tile, if found associated 
				}
				//
				else
					state_of_tile__neighbour__1D[i0] = C.none__state;

			}
			// STORE //



			// CLASSIFY //
			bool r_to_f__states_of_neighbouring =
				// (state_of_tile__neighbour__1D[0]  can be anything
				(state_of_tile__neighbour__1D[3] == (state_of_tile + 1) % 4) &&
				(state_of_tile__neighbour__1D[1] != (state_of_tile + 3) % 4) &&
				(state_of_tile__neighbour__1D[2] != (state_of_tile + 0) % 4);

			bool l_to_f__states_of_neighbouring =
				// (state_of_tile__neighbour__1D[0]  can be anything
				(state_of_tile__neighbour__1D[1] == (state_of_tile + 3) % 4) &&
				(state_of_tile__neighbour__1D[3] != (state_of_tile + 1) % 4) &&
				(state_of_tile__neighbour__1D[2] != (state_of_tile + 0) % 4);

			bool b_to_f__states_of_neighbouring =
				// (state_of_tile__neighbour__1D[0]  can be anything
				(state_of_tile__neighbour__1D[2] == (state_of_tile + 0) % 4);
			// (state_of_tile__neighbour__1D[1]  can be anything
			// (state_of_tile__neighbour__1D[3]  can be anything



			this.linkage_type = (r_to_f__states_of_neighbouring) ? C.r_to_f__linkage :
								(l_to_f__states_of_neighbouring) ? C.l_to_f__linkage :
								(b_to_f__states_of_neighbouring) ? C.b_to_f__linkage : C.none__linkage;


			// CLASSIFY //
		}


		//
		public void CLASSIFY_enter_flow__tile_type__tile_index_in_holder_()
		{

			TILE[] tile_1D = new TILE[4];

			for (int i0 = 1; i0 < 4; i0 += 1)
			{
				int[] dir = C.DIRS[(this.state_of_tile + i0) % 4];

				int[] pos = new int[2]
				{
					this.global_pos[0] + dir[0],
					this.global_pos[1] + dir[1],
				};


				tile_1D[i0] = STORE.GRID[pos[1]][pos[0]];
			}



			if (this.linkage_type == C.r_to_f__linkage)
			{
				// CONVEYOR_BELT__tile //
				if (tile_1D[3].TILE_TYPE == C.CONVEYOR_BELT__tile)
				{
					//
					enter_flow_type = tile_1D[3].TILE_TYPE;
					enter_flow_TILE_index = tile_1D[3].TILE_INDEX_in_HOLDER;
				}
				// CONVEYOR_BELT__tile //



				// MACHINE__tile //
				else if (tile_1D[3].TILE_TYPE == C.MACHINE__tile)
				{
					// TODO
				}
				// MACHINE__tile //

			}

			else if (this.linkage_type == C.l_to_f__linkage)
			{
				// CONVEYOR_BELT__tile //
				if (tile_1D[1].TILE_TYPE == C.CONVEYOR_BELT__tile)
				{
					enter_flow_type = tile_1D[1].TILE_TYPE;
					enter_flow_TILE_index = tile_1D[1].TILE_INDEX_in_HOLDER;
				}
				// CONVEYOR_BELT__tile //




				// MACHINE__tile //
				else if (tile_1D[1].TILE_TYPE == C.MACHINE__tile)
				{
					// TODO
				}
				// MACHINE__tile //

			}
			else if (this.linkage_type == C.b_to_f__linkage)
			{

				// CONVEYOR_BELT__tile //
				if (tile_1D[2].TILE_TYPE == C.CONVEYOR_BELT__tile)
				{
					enter_flow_type = tile_1D[2].TILE_TYPE;
					enter_flow_TILE_index = tile_1D[2].TILE_INDEX_in_HOLDER;
				}
				// CONVEYOR_BELT__tile //


				// MACHINE__tile //
				else if (tile_1D[2].TILE_TYPE == C.MACHINE__tile)
				{
					// TODO
				}
				// MACHINE__tile //

			}



			else if (this.linkage_type == C.none__linkage)
			{
				enter_flow_type = C.NONE__flow;
				enter_flow_TILE_index = C.none;
			}

			// CLASSIFY //



		}
		//


		public void CLASSIFY_exit_flow__tile_type__tile_index_in_holder_()
		{

			int[] dir = C.DIRS[(this.state_of_tile + 0) % 4];

			int[] pos = new int[2]
			{
				this.global_pos[0] + dir[0],
				this.global_pos[1] + dir[1],
			};

			TILE tile = STORE.GRID[pos[1]][pos[0]];



			// does not depend on linkage_type //
			// depend only on the local f neighbour tile //
			// CLASSIFY //
			if (tile.TILE_TYPE == C.CONVEYOR_BELT__tile)
			{
				CONVEYOR_BELT belt = STORE.CONVEYOR_BELT__1D[tile.TILE_INDEX_in_HOLDER];


				///  REQUIRE linkage_type to be classified ///
				//
				if (belt.state_of_tile == this.state_of_tile)
				{
					this.exit_flow_type = C.CONVEYOR_BELT__flow;
					this.exit_flow_TILE_index = tile.TILE_INDEX_in_HOLDER;
				}


				else if (belt.state_of_tile == (this.state_of_tile + 3) % 4)
				{
					if (belt.linkage_type == C.r_to_f__linkage)
					{
						this.exit_flow_type = C.CONVEYOR_BELT__tile;
						this.exit_flow_TILE_index = tile.TILE_INDEX_in_HOLDER;
					}
					else
					{
						this.exit_flow_type = C.NONE__flow;
						this.exit_flow_TILE_index = tile.TILE_INDEX_in_HOLDER;
					}
				}

				else if (belt.state_of_tile == (this.state_of_tile + 1) % 4)
				{
					if (belt.linkage_type == C.l_to_f__linkage)
					{
						this.exit_flow_type = C.CONVEYOR_BELT__tile;
						this.exit_flow_TILE_index = tile.TILE_INDEX_in_HOLDER;
					}
					else
					{
						this.exit_flow_type = C.NONE__flow;
						this.exit_flow_TILE_index = tile.TILE_INDEX_in_HOLDER;
					}
				}


				else
				{
					this.exit_flow_type = C.NONE__flow;
					this.exit_flow_TILE_index = tile.TILE_INDEX_in_HOLDER;
				}



			}
			else if (tile.TILE_TYPE == C.MACHINE__tile)
			{

				// TODO

			}






			// CLASSIFY //


		}
		#endregion


		#region CALCULATE_NEIGHBOURS_CONFIGURATION

		public int[][] CALCULATE_NEIGHBOURS_CONFIGURATION()
		{

			/*
				  f   l   b   r ( local )
				[   ,   ,   ,   ] -> state_of_tile
				[   ,   ,   ,   ] -> TYPE_of_TILE
				[   ,   ,   ,   ] -> TILE_INDEX
				[   ,   ,   ,   ] -> MACHINE_LET_TILE_INDEX
			*/


			int[][] NEIGHBOURS_CONFIGURATION = new int[4][]
			{
				new int[4],
				new int[4],
				new int[4],
				new int[4],
			};


			// all 4 DIRS local to state_of_tile //
			for (int i0 = 0; i0 < 4; i0 += 1)
			{

				// global_pos of tile //
				int[] pos = new int[2]
				{
					this.global_pos[0] + C.DIRS[ (this.state_of_tile + i0 ) % 4][0],
					this.global_pos[1] + C.DIRS[ (this.state_of_tile + i0 ) % 4][1],
				};
				// global_pos of tile //


				//

				TILE tile = STORE.GRID[pos[1]][pos[0]];

				if (tile.TILE_TYPE == C.CONVEYOR_BELT__tile)
				{
					CONVEYOR_BELT belt = STORE.CONVEYOR_BELT__1D[tile.TILE_INDEX_in_HOLDER];
					//
					NEIGHBOURS_CONFIGURATION[0][i0] = belt.state_of_tile;
					NEIGHBOURS_CONFIGURATION[1][i0] = C.CONVEYOR_BELT__tile;
					NEIGHBOURS_CONFIGURATION[2][i0] = tile.TILE_INDEX_in_HOLDER;
					NEIGHBOURS_CONFIGURATION[3][i0] = C.none;

				}

				else if (tile.TILE_TYPE == C.MACHINE__tile)
				{
					MACHINE machine = STORE.MACHINE__1D[tile.TILE_INDEX_in_HOLDER];


					int let_index = C.none;
					// let_index classify based on tile_associated
					//
					for (int i1 = 0; i1 < machine.LET_1D.Count; i1 += 1)
					{
						LET let = machine.LET_1D[i1];


						// weather let_tile_associated is curr tile, than let_index = i1


						// exclude block_let type //
						if (let.type_of_let != C.block_let)
						{
							// let
							int[] let__global_pos = new int[2]
							{
								machine.global_pos[0] + let.local_pos[0],
								machine.global_pos[1] + let.local_pos[1],
							};

							// let is at the pos (neighbour pos) 
							if (let__global_pos[0] == pos[0] &&
								let__global_pos[1] == pos[1])
							{
								// let_tile_associated
								int[] let_tile_associated__global_pos = new int[2]
								{
									machine.global_pos[0] + let.local_pos_of_tile_associated[0],
									machine.global_pos[1] + let.local_pos_of_tile_associated[1],
								};

								// let_tile_associated is curr tile
								if (let_tile_associated__global_pos[0] == this.global_pos[0] &&
									 let_tile_associated__global_pos[1] == this.global_pos[1])
								{
									let_index = i1;
									break;
								}
							}
							// let is at the pos (neighbour pos) 
						}


						// weather let_tile_associated is curr tile, than let_index = i1

					}


					// not found //
					if (let_index == C.none)
					{
						NEIGHBOURS_CONFIGURATION[0][i0] = C.none__state;
						NEIGHBOURS_CONFIGURATION[1][i0] = C.MACHINE__tile;
						NEIGHBOURS_CONFIGURATION[2][i0] = tile.TILE_INDEX_in_HOLDER;
						NEIGHBOURS_CONFIGURATION[3][i0] = C.none;
					}
					else
					{

						NEIGHBOURS_CONFIGURATION[0][i0] = machine.LET_1D[let_index].state_of_tile;
						NEIGHBOURS_CONFIGURATION[1][i0] = C.MACHINE__tile;
						NEIGHBOURS_CONFIGURATION[2][i0] = tile.TILE_INDEX_in_HOLDER;
						NEIGHBOURS_CONFIGURATION[3][i0] = let_index;
					}

				}

				else
				{
					NEIGHBOURS_CONFIGURATION[0][i0] = C.none__state;
					NEIGHBOURS_CONFIGURATION[1][i0] = C.NONE__tile;
					NEIGHBOURS_CONFIGURATION[2][i0] = C.none;
					NEIGHBOURS_CONFIGURATION[3][i0] = C.none;
				}

				//
			}



			return NEIGHBOURS_CONFIGURATION;
		}

		#endregion




		// TODO ---- DONE
		/*
		 not used anywhere in impleted so far 
			(could be used in indexing inside NEIGHBOURS_CONFIGURATION[][ index ] )
			(could be used as offset from state_of_tile while rotating dir)
		 
		will be used in GRID__TILE_DRAW

		  C.
			f__state = 0
			l__state = 1
			b__state = 2
			r__state = 3

		  C.DIRS
			[ +1 , 0 ]
			[  0 ,+1 ]
			[ -1 , 0 ]
			[  0 ,-1 ]
		*/





		public void CALCULATE__linkage_type__enter_flow()
		{
			int[][] NEIGHBOURS_CONFIGURATION = CALCULATE_NEIGHBOURS_CONFIGURATION();

			/*
				  f   l   b   r ( local )
				[   ,   ,   ,   ] -> state_of_tile
				[   ,   ,   ,   ] -> TYPE_of_TILE
				[   ,   ,   ,   ] -> TILE_INDEX
				[   ,   ,   ,   ] -> MACHINE_LET_TILE_INDEX
			*/



			int[] absolute__state_of_tile__1D = NEIGHBOURS_CONFIGURATION[0];

			bool r_to_f__linkage =
									//  state_of_tile__1D[0] can be anything
									(absolute__state_of_tile__1D[3] == (this.state_of_tile + 1) % 4) &&
									(absolute__state_of_tile__1D[1] != (this.state_of_tile + 3) % 4) &&
									(absolute__state_of_tile__1D[2] != (this.state_of_tile + 0) % 4);


			bool l_to_f__linkage =
									//  state_of_tile__1D[0] can be anything
									(absolute__state_of_tile__1D[1] == (this.state_of_tile + 3) % 4) &&
									(absolute__state_of_tile__1D[3] != (this.state_of_tile + 1) % 4) &&
									(absolute__state_of_tile__1D[2] != (this.state_of_tile + 0) % 4);

			bool b_to_f__linkage =
									//  state_of_tile__1D[0] can be anything
									//  state_of_tile__1D[1] can be anything
									//  state_of_tile__1D[3] can be anything
									(absolute__state_of_tile__1D[2] == (this.state_of_tile + 0) % 4);



			if (r_to_f__linkage)
			{
				this.linkage_type = C.r_to_f__linkage;

				this.enter_flow_type = NEIGHBOURS_CONFIGURATION[1][3];
				this.enter_flow_TILE_index = NEIGHBOURS_CONFIGURATION[2][3];
				this.enter_flow_TILE_LET_index = NEIGHBOURS_CONFIGURATION[3][3];

			}
			else if (l_to_f__linkage)
			{
				this.linkage_type = C.l_to_f__linkage;

				this.enter_flow_type = NEIGHBOURS_CONFIGURATION[1][1];
				this.enter_flow_TILE_index = NEIGHBOURS_CONFIGURATION[2][1];
				this.enter_flow_TILE_LET_index = NEIGHBOURS_CONFIGURATION[3][1];
			}
			else if (b_to_f__linkage)
			{
				this.linkage_type = C.b_to_f__linkage;

				this.enter_flow_type = NEIGHBOURS_CONFIGURATION[1][2];
				this.enter_flow_TILE_index = NEIGHBOURS_CONFIGURATION[2][2];
				this.enter_flow_TILE_LET_index = NEIGHBOURS_CONFIGURATION[3][2];
			}
			else
			{
				this.linkage_type = C.none__linkage;

				this.enter_flow_type = C.NONE__flow;
				this.enter_flow_TILE_index = C.none;
				this.enter_flow_TILE_LET_index = C.none;
			}



		}

		public void CALCULATE__exit_flow()
		{
			int[][] NEIGHBOURS_CONFIGURATION = CALCULATE_NEIGHBOURS_CONFIGURATION();

			/*
				  f   l   b   r ( local )
				[   ,   ,   ,   ] -> state_of_tile
				[   ,   ,   ,   ] -> TYPE_of_TILE
				[   ,   ,   ,   ] -> TILE_INDEX
				[   ,   ,   ,   ] -> MACHINE_LET_TILE_INDEX
			*/

			// linkage_type = [ relative to f ] r_to_f , l_to_f , b_to_f , none



			int absolute__state_of_tile__f = NEIGHBOURS_CONFIGURATION[0][0];

			if (absolute__state_of_tile__f == (this.state_of_tile + 0) % 4)
			{
				// CONVEYOR_BELT or MACHINE __TILE

				this.exit_flow_type = NEIGHBOURS_CONFIGURATION[1][0];
				this.exit_flow_TILE_index = NEIGHBOURS_CONFIGURATION[2][0];
				this.exit_flow_TILE_LET_index = NEIGHBOURS_CONFIGURATION[3][0];

			}
			else if (absolute__state_of_tile__f == (this.state_of_tile + 3) % 4)
			{
				//CONVEYOR_BELT __TILE

				CONVEYOR_BELT belt = STORE.CONVEYOR_BELT__1D[NEIGHBOURS_CONFIGURATION[2][0]];
				if (belt.linkage_type == C.r_to_f__linkage)
				{
					this.exit_flow_type = NEIGHBOURS_CONFIGURATION[1][0];
					this.exit_flow_TILE_index = NEIGHBOURS_CONFIGURATION[2][0];
					this.exit_flow_TILE_LET_index = NEIGHBOURS_CONFIGURATION[3][0];
				}
				else
				{
					this.exit_flow_type = C.NONE__tile;
					this.exit_flow_TILE_index = C.none;
					this.exit_flow_TILE_LET_index = C.none;
				}


			}
			else if (absolute__state_of_tile__f == (this.state_of_tile + 1) % 4)
			{
				//CONVEYOR_BELT __TILE

				CONVEYOR_BELT belt = STORE.CONVEYOR_BELT__1D[NEIGHBOURS_CONFIGURATION[2][0]];
				if (belt.linkage_type == C.l_to_f__linkage)
				{
					this.exit_flow_type = NEIGHBOURS_CONFIGURATION[1][0];
					this.exit_flow_TILE_index = NEIGHBOURS_CONFIGURATION[2][0];
					this.exit_flow_TILE_LET_index = NEIGHBOURS_CONFIGURATION[3][0];
				}
				else
				{
					this.exit_flow_type = C.NONE__tile;
					this.exit_flow_TILE_index = C.none;
					this.exit_flow_TILE_LET_index = C.none;
				}

			}
			else
			{
				//CONVEYOR_BELT or MACHINE or NONE __TILE
				this.exit_flow_type = C.NONE__tile;
				this.exit_flow_TILE_index = C.none;
				this.exit_flow_TILE_LET_index = C.none;
			}



		}


		/*
			0. call CALCULATE__linkage_type__enter_flow for every conveyor_belt so the linkage_type is found
			1. call CALCULATE__exit_flow
		*/


	}


	public class MACHINE
	{
		public int[] global_pos;                             // v2 global

		public List<LET> LET_1D;                             // L<LET>

		public int TYPE_OF_MACHINE;                          // PRODUCER , CONVERTER , COMBINER






		//// FUNCTIONALITY ////

		#region FUNCTIONALITY__MOVE_RESOURCES
		/*
			transfer payload from end_belt to the MACHINE(if exist)
			move the payload on CONVEYOR_BELT in the along the path
		*/


		public static void FUNCTIONALITY__MOVE_RESOURCES()
		{
			for (int i0 = 0; i0 < STORE.PATHS.Count; i0 += 1)
			{
				PATH path = STORE.PATHS[i0];


				// linear__move
				if (path.path_type != C.circular_path)
				{
					CONVEYOR_BELT end_belt = path.belts[path.belts.Count - 1];
					if (end_belt.exit_flow_TILE_index == C.MACHINE__flow)
					{
						STORE.MACHINE__1D[end_belt.exit_flow_TILE_index]
							.LET_1D[end_belt.exit_flow_TILE_LET_index]
							.payload = end_belt.payload;

						//
						end_belt.payload = C.none__payload;
					}


					for (int i1 = path.belts.Count - 2; i1 >= 0; i1 -= 1)
					{
						if (path.belts[i1 + 1].payload == C.none__payload)
						{
							path.belts[i1 + 1].payload = path.belts[i1].payload;
							path.belts[i1].payload = C.none__payload;
						}
					}
				}





			}
		}

		#endregion



		//// FUNCTIONALITY ////




	}

	public class LET
	{
		public int[] local_pos;                              // v2 local
		public int type_of_let;                              // inlet , outlet , block 


		public int[] local_pos_of_tile_associated;           // v2 local
		public int state_of_tile;                            // [absolute] r, f, l, b
		public int conveyor_belt__index_at_tile_associated;  // index , none


		public int resource_type_allowed;                    // resource_type , anything
		public int payload;                                  // resource_type , none
	}





	#region C CONSTANT / TILE_CONFIGURATION

	public static class C
	{

		// TILE_TYPE
		public static int CONVEYOR_BELT__tile = 0;
		public static int EMPTY__tile = 1;
		public static int MACHINE__tile = 2;
		public static int NONE__tile = -1;


		// state_of_tile
		public static int f__state = 0;
		public static int l__state = 1;
		public static int b__state = 2;
		public static int r__state = 3;
		public static int none__state = -1;

		// dir 
		// [absolute] r , f , l , b //
		public static int[][] DIRS = new int[4][]
		{
			new int[2] { +1 ,  0 },
			new int[2] {  0 , +1 },
			new int[2] { -1 ,  0 },
			new int[2] {  0 , -1 },
		};
		// [absolute] r , f , l , b //



		//[relative to state of tile] linkage_type
		public static int r_to_f__linkage = 0;
		public static int l_to_f__linkage = 1;
		public static int b_to_f__linkage = 2;
		public static int none__linkage = -1;


		// flow_type
		public static int CONVEYOR_BELT__flow = 0;
		public static int MACHINE__flow = 1;
		public static int NONE__flow = -1;


		// LET
		public static int inlet = 0;
		public static int outlet = 1;
		public static int block_let = -1;


		// resource_type
		public static int wood__resource = 0;
		public static int rock__resource = 1;
		public static int none__payload = -1;
		public static int any__payload = 100;



		// TYPE_OF_MACHINE
		public static int PRODUCER = 0;
		public static int CONVERTER = 1;
		public static int COMBINER = 2;


		// path_type
		public static int linear_path = 0;
		public static int circular_path = 1;



		// index
		public static int none = -1;

	}
	#endregion









	///// STUFF /////




	






	// INPUT ---- COMMAND ---- STORE
	#region COMMAND
	public static class COMMAND
	{

		#region COMMAND

		public static void COMMAND_CREATE__CONVEYOR_BELT(int[] pos, int state_of_tile = 0)
		{
			TILE tile = STORE.GRID[pos[1]][pos[0]];
			//
			if (tile.TILE_TYPE != C.EMPTY__tile)
			{
				return;
			}


			CONVEYOR_BELT belt = new CONVEYOR_BELT()
			{
				global_pos = pos,
				state_of_tile = state_of_tile,
				payload = C.none__payload,


				enter_flow_TILE_index = C.none,
				enter_flow_type = C.NONE__flow,
				enter_flow_TILE_LET_index = C.none,

				exit_flow_TILE_index = C.none,
				exit_flow_type = C.NONE__flow,
				exit_flow_TILE_LET_index = C.none,
			};



			// update in L<> CONVEYOR_BELT
			STORE.CONVEYOR_BELT__1D.Add(belt);
			// update in TILE[][] tile_type , tile_index_in_L<>
			tile.TILE_TYPE = C.CONVEYOR_BELT__tile;
			tile.TILE_INDEX_in_HOLDER = STORE.CONVEYOR_BELT__1D.Count - 1;
			// 

			// CALCULATION of belt __linkage __enter_flow __exit_flow
			// CALCULATION PATH

			STORE.UPDATE__CONVEYOR_BELT__CONFIGURATIONS__and__PATHS_CALCULATION();
		}


		public static void COMMAND_ROTATE__CONVEYOR_BELT(int[] pos)
		{

			// ROTATE //
			TILE tile = STORE.GRID[pos[1]][pos[0]];
			if (tile.TILE_TYPE != C.CONVEYOR_BELT__tile)
				return;

			CONVEYOR_BELT belt = STORE.CONVEYOR_BELT__1D[tile.TILE_INDEX_in_HOLDER];

			belt.state_of_tile = (belt.state_of_tile + 1) % 4;
			// ROTATE //



			// CALCULATE //
			STORE.UPDATE__CONVEYOR_BELT__CONFIGURATIONS__and__PATHS_CALCULATION();
			// CALCULATE //
			//
		}


		public static void COMMAND_PAYLOAD__CONVEYOR_BELT(int[] pos, int payload )
		{
			TILE tile = STORE.GRID[pos[1]][pos[0]];

			if(tile.TILE_TYPE == C.CONVEYOR_BELT__tile)
			{
				CONVEYOR_BELT belt = STORE.CONVEYOR_BELT__1D[tile.TILE_INDEX_in_HOLDER];

				belt.payload = payload;
			}


		}




		public static void COMMAND_REMOVE__CONVEYOR_BELT(int[] pos)
		{

			// REMOVE //
			TILE tile = STORE.GRID[pos[1]][pos[0]];
			if (tile.TILE_TYPE != C.CONVEYOR_BELT__tile)
				return;

			CONVEYOR_BELT belt = STORE.CONVEYOR_BELT__1D[tile.TILE_INDEX_in_HOLDER];



			Debug.Log(STORE.CONVEYOR_BELT__1D.Count);
			STORE.CONVEYOR_BELT__1D.Remove(belt);
			Debug.Log(STORE.CONVEYOR_BELT__1D.Count);


			// make it empty //
			STORE.GRID[pos[1]][pos[0]].TILE_TYPE = C.EMPTY__tile;
			STORE.GRID[pos[1]][pos[0]].TILE_INDEX_in_HOLDER = C.NONE__tile;
			// make it empty //




			// Re-index TILE_index_in_holder //
			for(int i0 = 0; i0 < STORE.CONVEYOR_BELT__1D.Count; i0 += 1)
			{
				int[] global_pos = STORE.CONVEYOR_BELT__1D[i0].global_pos;
				STORE.GRID[global_pos[1]][global_pos[0]].TILE_INDEX_in_HOLDER = i0;
			}
			// Re-index TILE_index_in_holder //






			// CALCULATE //
			STORE.UPDATE__CONVEYOR_BELT__CONFIGURATIONS__and__PATHS_CALCULATION();
			// CALCULATE //
			//
		}
		#endregion

	} 
	#endregion


	// COMMAND  ----  _INPUT_
	#region _INPUT_
	public static class _INPUT_
	{
		public static void EVENT(int[] dimension)
		{
			int w = dimension[0],
				h = dimension[1];

			int[] pos2D = new int[2]
			{
				round(_INPUT_.pos2D.x),
				round(_INPUT_.pos2D.z),
			};


			if (pos2D[0] <= 0 || pos2D[0] >= w - 1 || pos2D[1] <= 0 || pos2D[1] >= h - 1)
			{
				return;
			}



			if (Input.GetMouseButtonDown(0))
			{
				//
				if (Input.GetKey(KeyCode.R))
				{
					COMMAND.COMMAND_ROTATE__CONVEYOR_BELT(pos2D);
				}
				//
				else if (Input.GetKey(KeyCode.P)) { COMMAND.COMMAND_PAYLOAD__CONVEYOR_BELT(pos2D, C.rock__resource); }
				else if (Input.GetKey(KeyCode.W)) { COMMAND.COMMAND_PAYLOAD__CONVEYOR_BELT(pos2D, C.wood__resource); }


				//
				else if (Input.GetKey(KeyCode.X))
				{
					COMMAND.COMMAND_REMOVE__CONVEYOR_BELT(pos2D);
				}

				//
				else
				{
					COMMAND.COMMAND_CREATE__CONVEYOR_BELT(pos2D, state_of_tile: C.f__state);
				}
				//
			}




		}


		public static Camera cam;

		#region pos2D
		static Vector3 pos2D
		{
			get
			{
				Ray ray = cam.ScreenPointToRay(Input.mousePosition);

				Vector3 a = ray.origin,
						n = ray.direction;

				Vector3 o = Vector3.zero,
						up = Vector3.up;

				// ((a + L * n) - o).up = 0
				float L = -Z.dot(a - o, up) / Z.dot(n, up);

				return a + L * n;
			}

		}
		#endregion



		#region Z
		public static class Z
		{
			#region dot
			//
			public static float dot(Vector3 a, Vector3 b)
			{
				return a.x * b.x + a.y * b.y + a.z * b.z;
			}
			//
			#endregion

		}
		#endregion



		#region round

		public static int round(float x)
		{
			int x_I = (int)x;
			float fraction = x - x_I;

			if (x < 0f)
			{
				if (fraction <= -0.5f) return x_I - 1;
			}
			else if (x > 0f)
			{
				if (fraction >= 0.5f) return x_I + 1;
			}

			return x_I;
		}

		#endregion




	}

	#endregion



	// _RENDER_ ---- STORE , DRAW

	#region _RENDER_
	//
	public static class RENDER
	{
		public static void RENDER__DRAW_TILES(TILE[][] GRID)
		{
			int y_L = GRID[0].Length,
				x_L = GRID.Length;

			for (int y = 0; y < y_L; y += 1)
			{
				for (int x = 0; x < x_L; x += 1)
				{
					TILE tile = GRID[y][x];


					// EMPTY__tile //
					if (tile.TILE_TYPE == C.EMPTY__tile)
					{
						DRAW.col = RENDER.GRAY(0.5f);

						DRAW.QUAD(pos: V2(x, y));
						DRAW.DIR
						(
							pos : V2(x, y),
							state_of_tile : C.none__state
						);
					}

					// CONVEYOR_BELT__tile //
					else if (tile.TILE_TYPE == C.CONVEYOR_BELT__tile)
					{
						//
						CONVEYOR_BELT belt = STORE.CONVEYOR_BELT__1D[tile.TILE_INDEX_in_HOLDER];

						DRAW.col = RENDER.GRAY(0.8f);
						DRAW.QUAD(pos: V2(x, y));
						DRAW.DIR
						(
							pos : V2(x, y),
							state_of_tile : belt.state_of_tile 
						);


						if (belt.payload != C.none__payload)
						{
							//
							DRAW.col = (belt.payload == C.rock__resource)? 
								Color.HSVToRGB(0.66f, 0.5f, 0.75f) : 
								Color.HSVToRGB(0.1f , 0.5f, 0.50f);


							DRAW.QUAD(pos: V2(x, y), scale: 0.15f);
						}

					}


				}
			}

		}




		#region ad
		static Vector3 V2(int x, int y)
		{
			return new Vector3(x, 0f, y);
		}

		static Color GRAY(float x)
		{
			//
			return new Color(x, x, x, 1f);
		}

		#endregion

	}

	#endregion


	#region DRAW

	public static class DRAW
	{
		public static Color col = Color.red;
		public static float dt = Time.deltaTime;


		#region LINE
		public static void LINE(Vector3 a, Vector3 b, float de = 1f / 50)
		{

			Vector3 nX = b - a,
					nY = -Vector3.Cross(Vector3.up, nX).normalized;


			Debug.DrawLine(a - nY * de / 2, b - nY * de / 2, DRAW.col, DRAW.dt);
			Debug.DrawLine(a + nY * de / 2, b + nY * de / 2, DRAW.col, DRAW.dt);
		}
		#endregion



		#region QUAD
		public static void QUAD(Vector3 pos, float scale = 0.5f, float de = 1f / 50)
		{
			scale = scale * 0.95f;

			Vector3[] corners = new Vector3[4]
			{
				pos + new Vector3(+scale ,0f , -scale),
				pos + new Vector3(+scale ,0f , +scale),
				pos + new Vector3(-scale ,0f , +scale),
				pos + new Vector3(-scale ,0f , -scale),
			};


			scale -= de;

			Vector3[] corners_de = new Vector3[4]
			{
				pos + new Vector3(+scale ,0f , -scale),
				pos + new Vector3(+scale ,0f , +scale),
				pos + new Vector3(-scale ,0f , +scale),
				pos + new Vector3(-scale ,0f , -scale),
			};


			// draw SQ //
			for (int i = 0; i < corners.Length; i += 1)
			{
				Debug.DrawLine(corners[i], corners[(i + 1) % corners.Length], DRAW.col, DRAW.dt);
				Debug.DrawLine(corners_de[i], corners_de[(i + 1) % corners.Length], DRAW.col, DRAW.dt);
			}
			// draw SQ //

		}

		#endregion

		#region DIR
		public static void DIR(Vector3 pos, int state_of_tile = 0, float scale = 0.45f, float de = 1f / 50)
		{
			if (state_of_tile == -1)
			{
				Vector3[] P = new Vector3[4]
				{
					new Vector3(+0.2f,   0f,    -0.2f),
					new Vector3(-0.2f,   0f,    +0.2f),
					new Vector3(-0.2f,   0f,    -0.2f),
					new Vector3(+0.2f,   0f,    +0.2f),
				};


				DRAW.LINE(pos + P[0] * scale, pos + P[1] * scale);
				DRAW.LINE(pos + P[2] * scale, pos + P[3] * scale);


			}
			else if (state_of_tile != -1)
			{

				Vector3[] P = new Vector3[]
				{
					new Vector3(+0f     ,0f,  -0.5f),
					new Vector3(+0f     ,0f,  +0.5f),

					new Vector3(-0.2f   ,0f,  +0.2f),
					new Vector3(+0.2f   ,0f,  +0.2f),
				};


				Vector3[] new_P = new Vector3[P.Length];


				for (int i1 = 0; i1 < P.Length; i1 += 1)
				{
					// rotate by 90 catesian wise //
					new_P[i1] = new Vector3()
					{
						x = +P[i1].z,
						y = 0,
						z = -P[i1].x,
					};
					// rotate by 90 catesian wise //
					//
				}





				for (int i0 = 0; i0 < state_of_tile % 4; i0 += 1)
				{
					for (int i1 = 0; i1 < P.Length; i1 += 1)
					{
						// rotate by 90 catesian wise //
						new_P[i1] = new Vector3()
						{
							x = -new_P[i1].z,
							y = 0,
							z = +new_P[i1].x,
						};
						// rotate by 90 catesian wise //
						//
					}
				}







				DRAW.LINE(pos + new_P[0] * scale, pos + new_P[1] * scale);
				DRAW.LINE(pos + new_P[2] * scale, pos + new_P[1] * scale);
				DRAW.LINE(pos + new_P[3] * scale, pos + new_P[1] * scale);

			}



		}

		#endregion

	}

	#endregion




	#region LOG

	//
	public static class LOG
	{
		public static void FILE(string str)
		{
			//
			System.IO.File.WriteAllText(Application.dataPath + "/STORE/STORE.txt" , str);
			//
		}


		#region conveyor_belt__1D
		public static string conveyor_belt__1D(List<CONVEYOR_BELT> belts)
		{
			string str = "";


			for (int i0 = 0; i0 < belts.Count; i0 += 1)
			{
				// access by +1
				string[] state_of_tile__1D = new string[]
				{
					"none__state",
					"f__state",
					"l__state",
					"b__state",
					"r__state",
				};

				// access by +1
				string[] linkage_type__1D = new string[]
				{
					"none__linkage",
					"r_to_f__linkage",
					"l_to_f__linkage",
					"b_to_f__linkage",
				};


				str += "index_in__CONVEYOR_BELT__1D : " + i0 + '\n';

				str += "x : " + belts[i0].global_pos[0] + ", y : " + belts[i0].global_pos[1] + '\n' +
					   "state_of_tile : " + state_of_tile__1D[belts[i0].state_of_tile + 1] + '\n' +
					   "linkage_type : " + linkage_type__1D[belts[i0].linkage_type + 1] + '\n' +
					   "enter_flow : " + belts[i0].enter_flow_TILE_index + '\n' +
					   "exit_flow : " + belts[i0].exit_flow_TILE_index + '\n' +
					   "payload : " + belts[i0].payload;

				str += "\n\n";
			}



			return str;
		} 
		#endregion


		#region PATHS
		public static string PATHS(List<PATH> PATHS)
		{
			string str = "";

			string[] path_type__1D = new string[]
			{
				"linear_path",
				"circular_path"
			};

			for (int i0 = 0; i0 < PATHS.Count; i0 += 1)
			{
				str += "PATH__index__in__PATHS : " + i0 + '\n' +
						path_type__1D[PATHS[i0].path_type] + '\n';
				//
				for (int i1 = 0; i1 < PATHS[i0].belts.Count; i1 += 1)
				{
					str += "{ " + PATHS[i0].belts[i1].global_pos[0] + ", " + PATHS[i0].belts[i1].global_pos[1] + " }" + "  , ";
				}


				str += "\n\n\n\n";
			} 




			return str;
		}
		#endregion

	}
	//


	#endregion

}
